using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using ProjectMateTask.DAL.Entities.Base;
using ProjectMateTask.DAL.Repositories;
using ProjectMateTask.Infrastructure.CMD;
using ProjectMateTask.Infrastructure.MessageBuses;
using ProjectMateTask.Stores.Base;

namespace ProjectMateTask.VMD.Base;

internal class BaseSelectEntityVmd<TEntity> : BaseVmd where TEntity: INamedEntity,new()
{
    private readonly IRepository<TEntity> _entitiesRepository;
    
    private readonly IReadOnlyCollectionStore<IEntity> _subReadOnlyCollectionStore;

    #region SelectedEntity : Выбранная сущность

    private TEntity _selectedEntity;

    public TEntity SelectedEntity
    {
        get => _selectedEntity;
        set => Set(ref _selectedEntity, value);
    }

    #endregion
    
    #region Отфильтрованный список

    private CollectionViewSource _entitiesViewSource;

    public ICollectionView? EntitiesFilteredView => _entitiesViewSource?.View;

    #endregion
    
    #region Оригинльный список

    private ObservableCollection<TEntity> _entities;

    public ObservableCollection<TEntity> Entities
    {
        get => _entities;
        set
        {
            
            if (!Set(ref _entities, value)) return;
            
            _entitiesViewSource = new CollectionViewSource
            {
                Source = value,
                SortDescriptions =
                {
                    new SortDescription("Name", ListSortDirection.Ascending)
                }
            };

            _entitiesViewSource.Filter += OnEntityFilter;
            _entitiesViewSource.View.Refresh();

            OnPropertyChanged(nameof(EntitiesFilteredView));
        }
    }

    #endregion
    
    #region фильтация списка

    private string _filter;

    public string Filter
    {
        get => _filter;
        set
        {
            if (Set(ref _filter, value.ToLower()))
                _entitiesViewSource.View.Refresh();
        }
    }

    private void OnEntityFilter(object sender, FilterEventArgs e)
    {
        if (!(e.Item is NamedEntity entity) || string.IsNullOrEmpty(Filter)) return;

        if (!entity.Name.ToLower().Contains(Filter)) e.Accepted = false;
    }

    #endregion

    #region InitializeRepositoryAsync : Инициализация репозитория

    private async Task InitializeRepositoryAsync()
    {
        Entities = new ObservableCollection<TEntity>(await _entitiesRepository.PartTrackingItems.ToArrayAsync());
    }
    #endregion

    public BaseSelectEntityVmd(IRepository<TEntity> entitiesRepository,IReadOnlyCollectionStore<IEntity> subReadOnlyCollectionStore)
    {
        _entitiesRepository = entitiesRepository;
        
        _subReadOnlyCollectionStore = subReadOnlyCollectionStore;

        InitializeRepositoryAsync();

        #region Команды

            AddEntityCommand = new LambdaCmd(OnAddEntity);

        #endregion
        
    }

    #region AddEntityCommand : Добавление новой сущности 

    public ICommand AddEntityCommand { get; }

    private void OnAddEntity()
    {
        SelectedSubEntityMessageBus.Send(SelectedEntity);
    }

    #endregion
    
    
    
    
}