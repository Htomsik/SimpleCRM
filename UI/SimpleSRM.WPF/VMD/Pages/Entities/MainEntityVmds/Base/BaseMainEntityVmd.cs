using System;
using System.Threading.Tasks;
using System.Windows.Input;
using SimpleSRM.DAL.Repositories.Base;
using SimpleSRM.Models.Entities.Base;
using SimpleSRM.WPF.Infrastructure.CMD;
using SimpleSRM.WPF.Services.AppInfrastructure.NavigationServices.Base.TypeNavigationServices;
using SimpleSRM.WPF.Stores.AppInfrastructure.NavigationStores.Base;
using SimpleSRM.WPF.VMD.Pages.Entities.Base;
using SimpleSRM.WPF.VMD.Pages.Entities.SelectEntityVmds.Base;

namespace SimpleSRM.WPF.VMD.Pages.Entities.MainEntityVmds.Base;

/// <summary>
///     Базовая реализация для MainEntity vmd типов
/// </summary>
/// <typeparam name="TEntity">Любой NamedEntity тип</typeparam>
internal abstract class BaseMainEntityVmd<TEntity> : BaseEntityRepositoryVmd<TEntity>, IMainEntityVmd
    where TEntity : INamedEntity, new()
{
    #region Сервисы

    /// <summary>
    ///     Навигационный сервис для SubEntity (связных) vmd типов
    /// </summary>
    private readonly Lazy<ITypeNavigationServices> _selectedSubEntityTypeNavigationService;

    #endregion

    #region Хранилиша

    /// <summary>
    ///     Навигационное хранилище subEntity vmd типов (связных Entity)
    /// </summary>
    private readonly Lazy<IVmdNavigationStore<BaseEntityVmd>> _subEntityVmdNavigationStore;

    #endregion

    /// <summary>
    ///     Базовая реализация для MainEntity vmd типов
    /// </summary>
    /// <param name="entitiesRepository">Entity репозиторий</param>
    /// <param name="selectedSubEntityTypeNavigationService">Навигационный сервис для SubEntity (связных) vmd типов</param>
    /// <param name="subEntityVmdNavigationStore">Навигационное хранилище для выбраного SubEntity (связного) vmd типа</param>
    public BaseMainEntityVmd(IRepository<TEntity> entitiesRepository,
        ITypeNavigationServices selectedSubEntityTypeNavigationService,
        IVmdNavigationStore<BaseEntityVmd> subEntityVmdNavigationStore) : base(entitiesRepository)
    {
        #region Инициализация хранилищ и сервисов

        _selectedSubEntityTypeNavigationService =
            new Lazy<ITypeNavigationServices>(() => selectedSubEntityTypeNavigationService);

        _subEntityVmdNavigationStore = new Lazy<IVmdNavigationStore<BaseEntityVmd>>(() => subEntityVmdNavigationStore);

        #endregion

        #region Привязка подписок

        _subEntityVmdNavigationStore.Value.CurrentValueChanged +=
            () => OnPropertyChanged(nameof(CurrentSelectedSubEntityVmd));

        #endregion

        #region Инициализция команд

        OpenEditModeCommand = new LambdaCmd(OnOpenEditModeExecute, CanOpenEditMode);

        OpenAddModeCommand = new LambdaCmd(OnOpenAddEntityMode, CanOpenAddMode);

        CloseAllModsCommand = new LambdaCmd(OnCloseAllMods, CanCloseAllMods);

        AcceptAddModeCommand = new AsyncLambdaCmd(OnAddNewEntity, CanAddNewEntity);

        AcceptEditModeCommand = new AsyncLambdaCmd(OnAcceptEditEntity, CanAcceptEditEntity);


        DeleteSelectedEntityCommand = new AsyncLambdaCmd(OnDeleteSelectedEntity, CanDeleteSelectedEntity);

        DeleteSubEntityFromCollectionCommand = new LambdaCmd(OnDeleteSubEntityFromCollectionOriginal);

        OpenAddSubEntityModeInCollectionCommand = new LambdaCmd(OnOpenAddSubEntityModeInCollection);

        OpenChangeSubEntityMode = new LambdaCmd(OnOpenChangeSubEntityMode);

        #endregion
    }

    #region Методы

    public override void Dispose()
    {
        _selectedSubEntityTypeNavigationService.Value.Close();

        base.Dispose();
    }

    #endregion

    #region Поля и свойства

    public override string Tittle => typeof(TEntity).Name;

    #region CurrentSelectedSubEntityVmd : Текущая связная сущность

    public ISubEntityVmd? CurrentSelectedSubEntityVmd => _CurrentSelectedSubEntityVmd.Value;

    private Lazy<ISubEntityVmd> _CurrentSelectedSubEntityVmd =>
        new(() => (ISubEntityVmd)_subEntityVmdNavigationStore.Value.CurrentValue);

    #endregion

    #region Флаги (bool типы)

    /// <summary>
    ///     Флаг режима добавления SubEntity (связного) типа
    /// </summary>
    protected bool IsSubAddMode => CurrentSelectedSubEntityVmd is not null && IsEditMode;

    #region IsEditMode : Флаг режима редактирования

    /// <summary>
    ///     Флаг режима редактирования Entity
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

    private bool _isEditMode;

    #endregion

    #endregion

    #region Взаимодействующие Entity типы

    #region OriginalEntity : Оригинальная редактируемая/добавляемая Entity

    /// <summary>
    ///     Оригинальная редактируемая/добавляемая Entity
    /// </summary>
    protected TEntity? OriginalEntity
    {
        get => _originalEntity.Value;
        set => LaztSet(ref _originalEntity, value);
    }

    private Lazy<TEntity?> _originalEntity = new(() => default);

    #endregion

    #region SelectedEntity : Выбранная Entity из списка

    private Lazy<TEntity?> _selectedEntity = new(() => default);

    /// <summary>
    ///     Выбранная Entity из списка
    /// </summary>
    public TEntity? SelectedEntity
    {
        get => _selectedEntity.Value;

        set => LaztSet(ref _selectedEntity, value);
    }

    #endregion

    #region EditableEntity : Выбранная редактиуемая Entity

    private Lazy<TEntity?> _editableEntity = new(() => default);

    /// <summary>
    ///     Выбранная редактируемая Entity
    /// </summary>
    public TEntity? EditableEntity
    {
        get => _editableEntity.Value;
        set => LaztSet(ref _editableEntity, value);
    }

    #endregion

    #endregion

    #endregion

    #region Команды

    public ICommand AcceptModsCommand { get; set; }

    #region OpenEditModeCommand : Команда открытия режима редактирования Entity

    public ICommand OpenEditModeCommand { get; }

    private void OnOpenEditModeExecute()
    {
        var selectedEntityId = SelectedEntity.Id;

        EditableEntity = (TEntity?)EntitiesRepository.GetAsFullTracking(selectedEntityId);

        IsEditMode = true;
        AcceptModsCommand = AcceptEditModeCommand;
        OnPropertyChanged(nameof(AcceptModsCommand));
    }

    private bool CanOpenEditMode() =>SelectedEntity is not null && !IsEditMode;
    
    #endregion

    #region OpenAddModeCommand : Команда открытия режима добавления нового Entity

    public ICommand OpenAddModeCommand { get; }

    private void OnOpenAddEntityMode()
    {
        EditableEntity = new TEntity();
        IsEditMode = true;
        AcceptModsCommand = AcceptAddModeCommand;
        OnPropertyChanged(nameof(AcceptModsCommand));
    }

    private bool CanOpenAddMode() =>!IsEditMode;
    
    #endregion

    #region CloseAllMods : Команда закрытия  редактирования/добавления Entity

    public ICommand CloseAllModsCommand { get; }

    private void OnCloseAllMods() => IsEditMode = false;
    
    private bool CanCloseAllMods() =>!IsSubAddMode;
    
    #endregion

    #region AcceptAddModeCommand : Команда добавления новой сущности (принятия режима добавления)

    public ICommand AcceptAddModeCommand { get; }

    private async Task OnAddNewEntity()
    {
        EntitiesRepository.Add(EditableEntity);

        IsEditMode = false;

        await InitializeRepositoryAsync();
    }

    private bool CanAddNewEntity() =>!IsSubAddMode && (!OriginalEntity?.Equals(EditableEntity) ?? false) && !EditableEntity!.HasErrors;
    
    #endregion

    #region AcceptEditModeCommand : Команда принятия изменения выбранной Entity (принятия режима редактиования)

    public ICommand AcceptEditModeCommand { get; }

    private async Task OnAcceptEditEntity()
    {
        EntitiesRepository.Update(EditableEntity);
        IsEditMode = false;
        await InitializeRepositoryAsync();
    }

    private bool CanAcceptEditEntity() =>!IsSubAddMode && (!OriginalEntity?.Equals(EditableEntity) ?? false) && !EditableEntity!.HasErrors;
    
    #endregion

    #region DeleteSelectedEntityCommand : Команда удаления выбранной Entity

    public ICommand DeleteSelectedEntityCommand { get; }

    private async Task OnDeleteSelectedEntity()
    {
        var removedEntity = SelectedEntity;

        await EntitiesRepository.RemoveAsync(removedEntity);

        Entities.Remove(removedEntity);
    }

    private bool CanDeleteSelectedEntity() =>SelectedEntity is not null & !IsEditMode;
  

    #endregion

    #region DeleteSubEntityFromCollectionCommand : Команда удаления сущности из списа связанных элементов

    public ICommand DeleteSubEntityFromCollectionCommand { get; }

    private void OnDeleteSubEntityFromCollectionOriginal(object removedEntity)
    {
        OnDeleteSubEntityFromCollection((INamedEntity)removedEntity);
        OnPropertyChanged(nameof(EditableEntity));
    }

    /// <summary>
    ///     Метод удаления связного Entity из коллекции
    /// </summary>
    /// <param name="removedEntity">Удаляемая сущность</param>
    protected abstract void OnDeleteSubEntityFromCollection(INamedEntity removedEntity);

    #endregion

    #region OpenAddSubEntityModeInCollectionCommand : Команда открытия режима добавления новой дочерней сущности в коллекцию

    public ICommand OpenAddSubEntityModeInCollectionCommand { get; }

    protected virtual void OnOpenAddSubEntityModeInCollection(object addedEntity)
    {
        var subEntityType = addedEntity.GetType().GenericTypeArguments;

        _selectedSubEntityTypeNavigationService.Value.Navigate(subEntityType[0]);

        CurrentSelectedSubEntityVmd!.AddEntityNotifier += AddSubEntityInCollection;
    }

    /// <summary>
    ///     Метод для подписка на получение нового subEntity (связного) типа в коллекцию
    /// </summary>
    /// <param name="addedEntity"></param>
    protected abstract void AddSubEntityInCollection(INamedEntity addedEntity);

    #endregion

    #region OpenChangeSubEntityMode : Команда открытия режима смены связной Entity

    public ICommand OpenChangeSubEntityMode { get; }

    protected virtual void OnOpenChangeSubEntityMode(object subEntity)
    {
        var subEntityType = subEntity.GetType();

        _selectedSubEntityTypeNavigationService.Value.Navigate(subEntityType);

        CurrentSelectedSubEntityVmd!.AddEntityNotifier += ChangeSubEntity;
    }

    /// <summary>
    ///     Метод для подписки на получение нового  subEntity (связного)
    /// </summary>
    /// <param name="subEntity">Получаемый новый subEntity (связная) тип</param>
    /// <exception cref="NotSupportedException">
    ///     Возникает в случае если тип поддерживает смену связного Entity, но фактическая
    ///     реализация отсутсвует.
    /// </exception>
    protected virtual void ChangeSubEntity(INamedEntity subEntity) =>  throw new NotSupportedException($"Для vmd с типом: {typeof(TEntity)} не поддерживается смена связного Entity");
   

    #endregion

    #endregion
}