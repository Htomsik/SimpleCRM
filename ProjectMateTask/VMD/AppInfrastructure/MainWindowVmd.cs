using System;
using System.Windows.Input;
using Microsoft.Extensions.DependencyInjection;
using ProjectMateTask.Infrastructure.CMD;
using ProjectMateTask.Infrastructure.CMD.AppInfrastructure;
using ProjectMateTask.Infrastructure.MessageBuses.Base;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.CloseNavigationServices;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.NavigationServices;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores.Base;
using ProjectMateTask.VMD.Base;
using ProjectMateTask.VMD.Pages;
using ProjectMateTask.VMD.Pages.AdditionalPagesVmds.Base;
using ProjectMateTask.VMD.Pages.Entities.Base;

namespace ProjectMateTask.VMD.AppInfrastructure;

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
        IVmdNavigationStore<BaseVmd> mainMenuVmdNavigationStore,
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
    private readonly IVmdNavigationStore<BaseVmd> _mainMenuVmdNavigationStore;

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