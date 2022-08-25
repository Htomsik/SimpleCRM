using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using ProjectMateTask.DAL.Entities.Base;
using ProjectMateTask.DAL.Repositories;
using ProjectMateTask.Infrastructure.CMD;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.TypeNavigationServices;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores.Base;
using ProjectMateTask.VMD.Pages.SelectEntityVmds.Base;

namespace ProjectMateTask.VMD.Pages.EntityVmds.Base;

internal abstract class BaseEntityVmd<TEntity> : BaseNotGenericEntityVmd where TEntity : INamedEntity,new()
{
    private readonly ITypeNavigationServices _selectedSubEntityNavigationService;
    
    private readonly INavigationStore<BaseNotGenericSubEntityVmd> _subSubEntitySubNavigationStore;

    protected readonly IRepository<TEntity> EntitiesRepository;
    public ISelectEntityVmd? CurrentSelectedEntityPageVmd => (ISelectEntityVmd)_subSubEntitySubNavigationStore.CurrentVmd;
    public BaseEntityVmd(IRepository<TEntity> entitiesRepository,
        ITypeNavigationServices selectedSubEntityNavigationService,
        INavigationStore<BaseNotGenericSubEntityVmd> subSubEntitySubNavigationStore)
    {
        _selectedSubEntityNavigationService = selectedSubEntityNavigationService;
        
        _subSubEntitySubNavigationStore = subSubEntitySubNavigationStore;

        EntitiesRepository = entitiesRepository;
        
        _subSubEntitySubNavigationStore.CurrentVmdChanged += () => OnPropertyChanged(nameof(CurrentSelectedEntityPageVmd));
        
        InitializeRepositoryAsync();

        #region Команды

        ClearFilterCommand = new LambdaCmd(() => Filter = null, () => !string.IsNullOrEmpty(Filter));

        OpenEditModeCommand = new LambdaCmd(OnOpenEditModeExecute, CanOpenEditMode);

        OpenAddModeCommand = new LambdaCmd(OnOpenAddEntityMode, CanOpenAddMode);

        DeleteSelectedEntityCommand = new AsyncLambdaCmd(OnDeleteSelectedEntity, CanDeleteSelectedEntity);

        CloseAllModsCommand = new LambdaCmd(OnCloseAllMods,CanCloseAllMods);
        

        AcceptAddEntityModeCommand = new AsyncLambdaCmd(OnAddNewEntity, CanAddNewEntity);

        AcceptEditEntityModeCommand = new LambdaCmd(OnAcceptEditEntity, CanAcceptEditEntity);
        

        DeleteSubEntityFromCollection = new LambdaCmd(OnDeleteSubEntityFromCollectionOriginal);

        OpenAddSubEntityModeInCollectionCommand = new LambdaCmd(OnOpenAddSubEntityModeInCollection);

        OpenChangeSubEntityMode = new LambdaCmd(OnOpenChangeSubEntityMode);

        #endregion
    }
    
    /// <summary>
    /// Название страницы
    /// </summary>
    public override string Tittle => typeof(TEntity).Name;

    /// <summary>
    ///     Флаг режима редактирования
    /// </summary>
    public override bool IsEditMode
    {
        get => _isEditMode;
        set
        {
            if (!Set(ref _isEditMode, value)) return;
            
            if (value == false)
            {
                EditableEntity = default;
                OriginalEntity = default;
            }
            else
            {
                SelectedEntity = default;
                OriginalEntity = (TEntity?)EditableEntity!.Clone();
            }
            
        } 
    }
    
    #region IsSubAddMode : Флаг режима добавления subEntity
    public bool IsSubAddMode => CurrentSelectedEntityPageVmd is not null && IsEditMode;
    
    #endregion

    /// <summary>
    ///     Очистка фильтра поиска
    /// </summary>
    public ICommand ClearFilterCommand { get; }

    private async Task InitializeRepositoryAsync()
    {
        Entities = new ObservableCollection<TEntity>(await EntitiesRepository.PartTrackingItems.ToArrayAsync());
    }
    
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

    #region Отфильтрованный список

    private CollectionViewSource _entitiesViewSource;

    public ICollectionView? EntitiesFilteredView => _entitiesViewSource?.View;

    #endregion

    #region Выбранная сущность из списка

    private TEntity? _selectedEntity;

    public TEntity? SelectedEntity
    {
        get => _selectedEntity;
        set => Set(ref _selectedEntity, value);
    }

    #endregion

    #region редактиуемая сущность

    private TEntity? _editableEntity;
    public TEntity? EditableEntity
    {
        get => _editableEntity;
        set
        {
            Set(ref _editableEntity, value);
        } 
    }

    #endregion

    #region Оригинальная сущность

    private TEntity? _orignalEntity;
    public TEntity? OriginalEntity
    {
        get => _orignalEntity;
        set => Set(ref _orignalEntity, value);
    }

    #endregion
    
    #region OpenEditModeCommand : Команда открытия режима редактирования сущности

    /// <summary>
    ///     Команда редактирования
    /// </summary>
    public ICommand OpenEditModeCommand { get; }

    private void OnOpenEditModeExecute()
    {
        var selectedEntityId = SelectedEntity.Id;
        
        EditableEntity = EntitiesRepository.GetAsFullTracking(selectedEntityId);
        
        IsEditMode = true;
        AcceptModsCommand = AcceptEditEntityModeCommand;
        OnPropertyChanged(nameof(AcceptModsCommand));
    }

    private bool CanOpenEditMode() => SelectedEntity is not null && !IsEditMode;
   

    #endregion

    #region OpenAddModeCommand : Команда открытия режима добавления новой сущности

    public ICommand OpenAddModeCommand { get; }

    private void OnOpenAddEntityMode()
    {
        EditableEntity = new TEntity();
        IsEditMode = true;
        AcceptModsCommand = AcceptAddEntityModeCommand;
        OnPropertyChanged(nameof(AcceptModsCommand));
    }
    
    private bool CanOpenAddMode() => !IsEditMode;
    
    #endregion

    #region CloseAllMods : Команда закрытия режима редактирования/добавления

    public ICommand CloseAllModsCommand { get; }

    private void OnCloseAllMods() => IsEditMode = false;
    
    private bool CanCloseAllMods() => !IsSubAddMode;

    #endregion

    #region DeleteSelectedEntityCommand : Команда удаления сущности

    public ICommand DeleteSelectedEntityCommand { get; }

    private async Task OnDeleteSelectedEntity()
    {
        var removedEntity = SelectedEntity;

         await EntitiesRepository.RemoveAsync(removedEntity);

        Entities.Remove(removedEntity);
    }

    private bool CanDeleteSelectedEntity() => SelectedEntity is not null & !IsEditMode;
    
    #endregion

    #region AcceptAddEntityModeCommand : Команда добавления сущности

    public ICommand AcceptAddEntityModeCommand { get; }

    private  async Task OnAddNewEntity()
    {
        EntitiesRepository.Add(EditableEntity);
        
        IsEditMode = false;

        await  InitializeRepositoryAsync();
    }
    private bool CanAddNewEntity() =>  !IsSubAddMode && (!OriginalEntity?.Equals(EditableEntity) ?? false) && !EditableEntity!.HasErrors;
    
    #endregion

    #region AcceptModsCommand : Свич команда между режимами

    public ICommand AcceptModsCommand { get; set; }

    #endregion

    #region AcсeptEditEntity : Команда принятия изменений

    public ICommand AcceptEditEntityModeCommand { get; set; }

    private async void OnAcceptEditEntity()
    {
        EntitiesRepository.Update(EditableEntity);
        IsEditMode = false;
        await InitializeRepositoryAsync();
    }

    private bool CanAcceptEditEntity() => !IsSubAddMode && (!OriginalEntity?.Equals(EditableEntity) ?? false) && !EditableEntity!.HasErrors;
    
    #endregion

    #region DeleteSubEntityFromCollection : Команда удаления сущности из списа связанных элементов

    public ICommand DeleteSubEntityFromCollection { get; }


    private void OnDeleteSubEntityFromCollectionOriginal(object p)
    {
        OnDeleteSubEntityFromCollection(p);
        OnPropertyChanged(nameof(EditableEntity));
    }
    protected abstract void OnDeleteSubEntityFromCollection(object p);


    #endregion

    #region OpenAddSubEntityModeInCollectionCommand : Команда открытия режима добавления новой дочерней сущности в коллекцию 
    
    public ICommand OpenAddSubEntityModeInCollectionCommand { get; }

    protected virtual void OnOpenAddSubEntityModeInCollection(object p)
    {
        //Получение типа Entity в коллекции
        
        var subEntityType = p.GetType().GenericTypeArguments;
        
        _selectedSubEntityNavigationService.Navigate(subEntityType[0]);

        CurrentSelectedEntityPageVmd!.AddEntityNotifier += AddSubEntityInCollection;

    }
    
    protected abstract void AddSubEntityInCollection(INamedEntity entity);
    
    #endregion
    
    #region OpenChangeSubEntityMode : команда добавления/изменения дочерней сущности

    public ICommand OpenChangeSubEntityMode { get; }
    
    protected virtual void OnOpenChangeSubEntityMode(object p)
    {
        
        var subEntityType = p.GetType();
        
        _selectedSubEntityNavigationService.Navigate(subEntityType);

        
        CurrentSelectedEntityPageVmd!.AddEntityNotifier += ChangeSubEntity;

    }


    protected virtual void ChangeSubEntity(INamedEntity entity)
    {
        
    }
   

    #endregion
    
    #region Dispose

    public override void Dispose()
    {
       _selectedSubEntityNavigationService.Close();
      
        base.Dispose();
    }

    #endregion
}