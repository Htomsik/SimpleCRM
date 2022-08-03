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
using ProjectMateTask.DAL.Entities.Types;
using ProjectMateTask.DAL.Repositories;
using ProjectMateTask.Infrastructure.CMD;
using ProjectMateTask.VMD.Pages.SelectEntityPages;

namespace ProjectMateTask.VMD.Base;

internal abstract class BaseEntityPageVmd<TEntity> : BaseNotGenericEntityVmd where TEntity : INamedEntity,new()
{
    private readonly IRepository<TEntity> _entitiesRepository;

    public BaseVmd CurrentSelectEntityPageVmd;

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
        Entities = new ObservableCollection<TEntity>(await _entitiesRepository.PartTrackingItems.ToArrayAsync());
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
        var selectedEntityId = SelectedEntity.Id;
        //Клонирование сущности для редактирования
        EditableEntity = _entitiesRepository.GetAsFullTracking(selectedEntityId);

        //Сохранение оригинальной редактируемой сущности
        OriginalEntity = (TEntity)EditableEntity.Clone();

        //Обнуление выбранного элемента для того чтобы wpf подхватил EditableEntity
        SelectedEntity = default;
        
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
        SelectedEntity = default;
        IsEditMode = false;
    }

    #endregion

    #region DeleteSelectedEntityCommand : Команда удаления сущности

    public ICommand DeleteSelectedEntityCommand { get; }

    private async Task OnDeleteSelectedEntity()
    {
        var removedEntity = SelectedEntity;

         await _entitiesRepository.RemoveAsync(removedEntity);

        Entities.Remove(removedEntity);
    }

    private bool CanDeleteSelectedEntity()
    {
        return SelectedEntity is not null & !IsEditMode;
    }

    #endregion

    #region AddNewEntity : Команда добавления сущности

    public ICommand AddNewEntity { get; }

    private  async Task OnAddNewEntity()
    {
      //   var addedEntity = SelectedEntity;
      //   
      // Task addAsync =  _entitiesRepository.AddAsync(addedEntity);
      //   
      // Task addAsyncSubEntities =  OnAddSubEntities();
      //
      // await Task.WhenAll(addAsync, addAsyncSubEntities);
      //
      // await InitializeRepositoryAsync();
    }

    protected virtual async Task OnAddSubEntities() {}
    

    private bool CanAddNewEntity() => !IsEditMode;
    #endregion

    #region AcсeptEditEntity : Команда принятия изменений

    public ICommand AcceptEditEntityCommand { get; set; }

    private void OnAcceptEditEntity()
    {
        _entitiesRepository.Update(EditableEntity);
        
        IsEditMode = false;

        EditableEntity = default;

        OriginalEntity = default;

        InitializeRepositoryAsync();
    }

    private bool CanAcceptEditEntity()
    {
         return !OriginalEntity?.Equals(EditableEntity) ?? false;
        
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