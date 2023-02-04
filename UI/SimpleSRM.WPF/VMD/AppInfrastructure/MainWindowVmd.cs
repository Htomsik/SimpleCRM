using System.Windows.Input;
using Microsoft.Extensions.DependencyInjection;
using SimpleSRM.WPF.Infrastructure.CMD;
using SimpleSRM.WPF.Infrastructure.CMD.AppInfrastructure;
using SimpleSRM.WPF.Infrastructure.MessageBuses.Base;
using SimpleSRM.WPF.Services.AppInfrastructure.NavigationServices.Base.CloseNavigationServices;
using SimpleSRM.WPF.Services.AppInfrastructure.NavigationServices.Base.NavigationServices;
using SimpleSRM.WPF.Stores.AppInfrastructure.NavigationStores.Base;
using SimpleSRM.WPF.VMD.AppInfrastructure.MenuVMds.Base;
using SimpleSRM.WPF.VMD.Base;
using SimpleSRM.WPF.VMD.Pages;
using SimpleSRM.WPF.VMD.Pages.AdditionalPagesVmds.Base;
using SimpleSRM.WPF.VMD.Pages.Entities.Base;

namespace SimpleSRM.WPF.VMD.AppInfrastructure;

/// <summary>
///     Vmd для главного окна
/// </summary>
internal sealed class MainWindowVmd : BaseVmd
{
    /// <summary>
    ///     Vmd для главного окна
    /// </summary>
    /// <param name="mainEntityVmdNavigationStore">Навигационное хранилище MainEntity vmd типов</param>
    /// <param name="closeMainEntityNavigationServices">Сервис закрытия MainEntity vmd типов</param>
    /// <param name="mainMenuVmdNavigationStore">Навигационное хранилище menu vmd типов</param>
    /// <param name="additionalVmdNavigationStore">Навигационное хранилише доп vmd типов</param>
    /// <param name="openSettingsNavigationServices">Сервис открытия настроек</param>
    /// <param name="loggerMessageBus">Шина сообщений от логгера</param>
    public MainWindowVmd(IEntityVmdNavigationStore<BaseEntityVmd> mainEntityVmdNavigationStore,
        ICloseNavigationServices closeMainEntityNavigationServices,
        IVmdNavigationStore<BaseMenuNavigationVmd> mainMenuVmdNavigationStore,
        IVmdNavigationStore<BaseAdditionalVmd> additionalVmdNavigationStore,
        INavigationService openSettingsNavigationServices,
        IMessageBus<string> loggerMessageBus)
    {
        #region Инициализация сервисов или хранилищ

        _mainEntityVmdNavigationStore = mainEntityVmdNavigationStore;
        
        _mainMenuVmdNavigationStore = mainMenuVmdNavigationStore;

        _additionalVmdNavigationStore = additionalVmdNavigationStore;

        #endregion

        #region Привязка подписок

        _mainEntityVmdNavigationStore.CurrentValueChanged += () => OnPropertyChanged(nameof(MainEntityOrHomeCurrentVmd));

        _additionalVmdNavigationStore.CurrentValueChanged += () => OnPropertyChanged(nameof(AdditionalCurrenVmd));

        loggerMessageBus.Bus += logMes => LoggingInfo = logMes;

        #endregion

        #region Инициализация команд

        OpenSettingsCommand = new NavigationCmd(openSettingsNavigationServices);

        OpenHomeCommand = new LambdaCmd(()=> closeMainEntityNavigationServices.Close());

        #endregion
        
    }

    #region Команды

    /// <summary>
    ///     Команда открытия настроек
    /// </summary>
    public ICommand OpenSettingsCommand { get; }

    /// <summary>
    ///     Команда открытия домашней страницы
    /// </summary>
    public ICommand OpenHomeCommand { get; }
    
    #endregion

    #region Хранилища

    /// <summary>
    ///     Навигационное хранилище доп vmd типов
    /// </summary>
    private readonly IVmdNavigationStore<BaseAdditionalVmd> _additionalVmdNavigationStore;

    /// <summary>
    ///     Навигационное хранилище menuVmd типов
    /// </summary>
    private readonly IVmdNavigationStore<BaseMenuNavigationVmd> _mainMenuVmdNavigationStore;

    /// <summary>
    ///     Навигционное хранилище MainEntity vmd типов
    /// </summary>
    private readonly IEntityVmdNavigationStore<BaseEntityVmd> _mainEntityVmdNavigationStore;
    
    #endregion

    #region Поля и свойства


    #region MainEntityOrHomeCurrentVmd : Текущая выбранная Entity или домашняя страница
    
    /// <summary>
    ///     Текущая выбранная MainEntityVmd или HomeVmd
    /// </summary>
    public BaseVmd? MainEntityOrHomeCurrentVmd => (BaseVmd?)_mainEntityVmdNavigationStore.CurrentValue ?? App.Services.GetRequiredService<HomeVmd>();

    #endregion
    
    /// <summary>
    ///     Текущая выбранная доп страница
    /// </summary>
    public IAdditionalVmd? AdditionalCurrenVmd => _additionalVmdNavigationStore.CurrentValue;

    /// <summary>
    ///     Текущая выбранная menu страница
    /// </summary>
    public BaseVmd? MainMenuCurrentVmd => _mainMenuVmdNavigationStore.CurrentValue;

    #region LoggingInfo : Последнее пришедшее сообщение от логгера

    /// <summary>
    ///     Последнее пришедшее сообщение от логгера
    /// </summary>
    public string LoggingInfo
    {
        get => _loggingInfo;
        set => Set(ref _loggingInfo, value);
    }

    private string _loggingInfo;

    #endregion

    #endregion
}