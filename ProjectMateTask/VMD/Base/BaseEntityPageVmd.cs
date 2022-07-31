using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using System.Xml.Linq;
using Mapster;
using Microsoft.EntityFrameworkCore;
using ProjectMateTask.DAL.Entities.Actors;
using ProjectMateTask.DAL.Entities.Base;
using ProjectMateTask.DAL.Repositories;
using ProjectMateTask.Infrastructure.CMD;

namespace ProjectMateTask.VMD.Base;

internal abstract class BaseEntityPageVmd<TEntity> : BaseNotGenericEntityVmd where TEntity : NamedEntity, new()
{
    private readonly IRepository<TEntity> _entitiesRepository;

    public BaseEntityPageVmd(IRepository<TEntity> entitiesRepository)
    {
        _entitiesRepository = entitiesRepository;

        InitializeRepositoryAsync();

        #region Команды

        ClearFilterCommand = new LambdaCmd(() => Filter = null, () => !string.IsNullOrEmpty(Filter));

        OpenEditModeCommand = new LambdaCmd(OnOpenEditModeExecute, CanOpenEditMode);

        OpenAddModeCommand = new LambdaCmd(OnOpenAddEntityMode, CanOpenAddMode);

        DeleteSelectedEntityCommand = new AsyncLambdaCmd(OnDeleteSelectedEntity, CanDeleteSelectedEntity);

        CloseAllModsCommand = new LambdaCmd(OnCloseAllMods);

        AddNewEntity = new AsyncLambdaCmd(OnAddNewEntity, CanAddNewEntity);

        AcceptEditEntityCommand = new LambdaCmd(OnAcceptEditEntity, CanAcceptEditEntity);

        DeleteSubEntityFromCollection = new LambdaCmd(OnDeleteSubEntityFromCollectionOriginal);

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
        set => Set(ref _isEditMode, value);
    }

    /// <summary>
    ///     Очистка фильтра поиска
    /// </summary>
    public ICommand ClearFilterCommand { get; }

    private async Task InitializeRepositoryAsync()
    {
        Entities = new ObservableCollection<TEntity>(await _entitiesRepository.Items.ToArrayAsync());
    }


    #region SubEntity


    private IEntity _selectedSubEntity;
    
    public IEntity SelectedSubEntity 
    { 
        get => _selectedSubEntity; 
        set=> Set(ref _selectedSubEntity,value);
        
    }

    #endregion

    #region Оригинльный список

    private ObservableCollection<TEntity> _entities;

    public ObservableCollection<TEntity> Entities
    {
        get => _entities;
        set
        {
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

    private TEntity _selectedEntity;

    public TEntity SelectedEntity
    {
        get => _selectedEntity;
        set => Set(ref _selectedEntity, value);
    }

    #endregion

    #region редактиуемая сущность

    private TEntity _editableEntity;
    public TEntity EditableEntity
    {
        get => _editableEntity;
        set => Set(ref _editableEntity, value);
    }

    #endregion

    #region Оригинальная сущность

    private TEntity _orignalEntity;
    public TEntity OriginalEntity
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
        //Клонирование сущности для редактирования
        EditableEntity =  (TEntity)SelectedEntity.Clone();

        //Сохранение оригинальной редактируемой сущности
        OriginalEntity = (TEntity)SelectedEntity.Clone();

        //Обнуление выбранного элемента для того чтобы wpf подхватил EditableEntity
        SelectedEntity = null;
        
        IsEditMode = true;
    }

    private bool CanOpenEditMode() => SelectedEntity is not null && !IsEditMode;
   

    #endregion

    #region OpenAddModeCommand : Команда открытия режима добавления новой сущности

    public ICommand OpenAddModeCommand { get; }

    private void OnOpenAddEntityMode()
    {
        IsEditMode = true;
        SelectedEntity = new TEntity();
    }

    private bool CanOpenAddMode()
    {
        return !IsEditMode;
    }

    #endregion

    #region CloseAllMods : Команда закрытия режима редактирования/добавления

    public ICommand CloseAllModsCommand { get; }

    private void OnCloseAllMods()
    {
        SelectedEntity = null;
        IsEditMode = false;
    }

    #endregion

    #region DeleteSelectedEntityCommand : Команда удаления сущности

    public ICommand DeleteSelectedEntityCommand { get; }

    private async Task OnDeleteSelectedEntity()
    {
        var removedEntity = SelectedEntity;

        await _entitiesRepository.RemoveAsync(removedEntity);

        await InitializeRepositoryAsync();
    }

    private bool CanDeleteSelectedEntity()
    {
        return SelectedEntity is not null & !IsEditMode;
    }

    #endregion

    #region AddNewEntity : Команда добавления сущности

    public ICommand AddNewEntity { get; }

    private async Task OnAddNewEntity()
    {
        var addedEntity = SelectedEntity;

        await _entitiesRepository.AddAsync(addedEntity);

        await InitializeRepositoryAsync();
    }

    private bool CanAddNewEntity()
    {
        return SelectedEntity is not null;
    }

    #endregion

    #region AcсeptEditEntity : Команда принятия изменений

    public ICommand AcceptEditEntityCommand { get; set; }

    private void OnAcceptEditEntity()
    {
   
    }

    private bool CanAcceptEditEntity()
    {
        if (SelectedEntity is null)
            return false;
        
        var test = OriginalEntity?.Equals(SelectedEntity);
        
        return !test ?? false;
    }


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
}