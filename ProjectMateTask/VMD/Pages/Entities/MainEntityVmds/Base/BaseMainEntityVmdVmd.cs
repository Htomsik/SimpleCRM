using System.Collections.Generic;
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
using ProjectMateTask.VMD.Base;
using ProjectMateTask.VMD.Pages.Entities.Base;
using ProjectMateTask.VMD.Pages.Entities.SelectEntityVmds.Base;

namespace ProjectMateTask.VMD.Pages.Entities.MainEntityVmds.Base;

internal abstract class BaseMainEntityVmdVmd<TEntity> : BaseEntityRepositoryVmd<TEntity> where TEntity : INamedEntity, new()
{
    private readonly ITypeNavigationServices _selectedSubEntityTypeNavigationService;
    
    private readonly  IVmdNavigationStore<BaseEntityVmd> _subEntityVmdNavigationStore;
    public ISubEntityVmd? CurrentSelectedEntityPageVmd => (ISubEntityVmd)_subEntityVmdNavigationStore.CurrentValue;
    
    public BaseMainEntityVmdVmd(IRepository<TEntity> entitiesRepository,
        ITypeNavigationServices selectedSubEntityTypeNavigationService,
        IVmdNavigationStore<BaseEntityVmd> subEntityVmdNavigationStore) : base(entitiesRepository)
    {
        _selectedSubEntityTypeNavigationService = selectedSubEntityTypeNavigationService;
        
        _subEntityVmdNavigationStore = subEntityVmdNavigationStore;
        
        _subEntityVmdNavigationStore.CurrentValueChanged += () => OnPropertyChanged(nameof(CurrentSelectedEntityPageVmd));
        
        #region Команды
        
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
    
    #region IsEditMode : Флаг режима редактирования

    /// <summary>
    ///     Флаг режима редактирования
    /// </summary>
    public bool IsEditMode
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
    
    protected bool _isEditMode;

    #endregion
    
    #region IsSubAddMode : Флаг режима добавления subEntity
    public bool IsSubAddMode => CurrentSelectedEntityPageVmd is not null && IsEditMode;
    
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
        
        EditableEntity = (TEntity?)EntitiesRepository.GetAsFullTracking(selectedEntityId);
        
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
        
        _selectedSubEntityTypeNavigationService.Navigate(subEntityType[0]);

        CurrentSelectedEntityPageVmd!.AddEntityNotifier += AddSubEntityInCollection;

    }
    
    protected abstract void AddSubEntityInCollection(INamedEntity entity);
    
    #endregion
    
    #region OpenChangeSubEntityMode : команда добавления/изменения дочерней сущности

    public ICommand OpenChangeSubEntityMode { get; }
    
    protected virtual void OnOpenChangeSubEntityMode(object p)
    {
        
        var subEntityType = p.GetType();
        
        _selectedSubEntityTypeNavigationService.Navigate(subEntityType);

        
        CurrentSelectedEntityPageVmd!.AddEntityNotifier += ChangeSubEntity;

    }


    protected virtual void ChangeSubEntity(INamedEntity entity)
    {
        
    }
   

    #endregion
    
    #region Dispose

    public override void Dispose()
    {
       _selectedSubEntityTypeNavigationService.Close();
      
        base.Dispose();
    }
    
   

    #endregion
}