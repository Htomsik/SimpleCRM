using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Data;
using Microsoft.EntityFrameworkCore;
using ProjectMateTask.DAL.Entities.Base;
using ProjectMateTask.DAL.Repositories;

namespace ProjectMateTask.VMD.Pages.Entities.Base;

/// <summary>
///     Базовая реализация для EntityVmd типов поддерживающих работу с репозиториями
/// </summary>
/// <typeparam name="TEntity"></typeparam>
internal abstract class BaseEntityRepositoryVmd<TEntity> : BaseEntityVmd where TEntity : INamedEntity
{
    /// <summary>
    ///     Базовая реализация для EntityVmd типов поддерживающих работу с репозиториями
    /// </summary>
    /// <param name="entitiesRepository">Entity репозитоий</param>
    public BaseEntityRepositoryVmd(IRepository<TEntity> entitiesRepository)
    {
        #region Инициализация полей и свойств

        EntitiesRepository = entitiesRepository;

        #endregion

        InitializeRepositoryAsync();
    }

    #region Поля и Свойства

    #region Entities : Не фильтрованный список

    private ObservableCollection<TEntity> _entities;

    /// <summary>
    ///     Коллекция не фильтрованных Entity
    /// </summary>
    public virtual ObservableCollection<TEntity> Entities
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

    #region Filter : Парамет фильтрации

    private string? _filter;

    /// <summary>
    ///     Параметр, по которому происходит фильтрация
    /// </summary>
    public virtual string? Filter
    {
        get => _filter;
        set
        {
            if (Set(ref _filter, value?.ToLower()))
                _entitiesViewSource.View.Refresh();
        }
    }

    #endregion

    protected readonly IRepository<TEntity> EntitiesRepository;
    public override string Tittle => typeof(TEntity).Name;

    #endregion

    #region Методы

    /// <summary>
    ///     Инициаализация репозитория
    /// </summary>
    protected virtual async Task InitializeRepositoryAsync()
    {
        Entities = new ObservableCollection<TEntity>(await EntitiesRepository.PartTrackingItems.ToArrayAsync());
    }


    /// <summary>
    ///     Метод фильтрации коллекции
    /// </summary>
    /// <param name="sender">Отправитель</param>
    /// <param name="e">Аргумент фильтрации</param>
    protected virtual void OnEntityFilter(object sender, FilterEventArgs e)
    {
        if (!(e.Item is INamedEntity entity) || string.IsNullOrEmpty(Filter)) return;

        if (!entity.Name.ToLower().Contains(Filter)) e.Accepted = false;
    }

    #endregion
}