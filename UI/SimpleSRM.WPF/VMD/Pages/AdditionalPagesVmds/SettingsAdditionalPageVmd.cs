using System.Collections.ObjectModel;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using SimpleSRM.WPF.Infrastructure.CMD.AppInfrastructure;
using SimpleSRM.WPF.Models.AppInfrastructure;
using SimpleSRM.WPF.Services.AppInfrastructure.NavigationServices.Base.TypeNavigationServices;
using SimpleSRM.WPF.Services.AppInfrastructure.NavigationServices.CloseNavigationServcies;
using SimpleSRM.WPF.Stores.AppInfrastructure.NavigationStores.Base;
using SimpleSRM.WPF.VMD.Base;
using SimpleSRM.WPF.VMD.Pages.AdditionalPagesVmds.Base;
using SimpleSRM.WPF.VMD.Pages.SettingsVmds;

namespace SimpleSRM.WPF.VMD.Pages.AdditionalPagesVmds;

/// <summary>
///     Настройки приложения (Vmd для доп окна)
/// </summary>
internal sealed class SettingsAdditionalPageVmd : BaseAdditionalVmd
{
    #region Хранилища

    /// <summary>
    ///     Локальное навигационное хранилище для vmd страниц настроек
    /// </summary>
    private readonly IVmdNavigationStore<BaseVmd> _localVmdNavigationStore;

    #endregion

    #region Сервисы

    /// <summary>
    ///     Навигационный сервис vmd страниц настроек для локального хранилища
    /// </summary>
    private readonly ITypeNavigationServices _typeNavigationServices;

    #endregion

    /// <summary>
    ///     Настройки приложения (Vmd для доп окна)
    /// </summary>
    /// <param name="closeAdditionalNavigationService">Сервис закрытия доп окна</param>
    public SettingsAdditionalPageVmd(CloseAdditionalPageNavigationServices closeAdditionalNavigationService) : base(
        closeAdditionalNavigationService)
    {
        #region Инициализация сервисов или хранилищ

        _localVmdNavigationStore = new BaseVmdNavigationStore<BaseVmd>();

        _typeNavigationServices = new BaseTypeNavigationServices<BaseVmd>(_localVmdNavigationStore);

        #endregion

        #region Привязка подписок

        _localVmdNavigationStore.CurrentValueChanged += () => OnPropertyChanged(nameof(CurrentSettingsPageVmd));

        #endregion

        #region Инициализация команд

        MenuNavigationCommand = new TypeNavigationCmd(_typeNavigationServices, () => true);

        #endregion

        #region Инициалимзация свойств

        MenuItems = new ObservableCollection<MenuItemWithCommand>
        {
            new("О программе", PackIconKind.Home, MenuNavigationCommand, typeof(AboutProgramVmd))
        };

        #endregion
        
        _typeNavigationServices.Navigate(typeof(AboutProgramVmd));
        
    }

    #region Команды

    /// <summary>
    ///     Команда навигации по vmd страницам настроек
    /// </summary>
    public ICommand MenuNavigationCommand { get; }

    #endregion

    #region Поля и свойства

    /// <summary>
    ///     Текущая выбранная vmd страница настроек
    /// </summary>
    public BaseVmd CurrentSettingsPageVmd => _localVmdNavigationStore?.CurrentValue!;

    /// <summary>
    ///     Коллекцию навигационного меню для страниц настроек
    /// </summary>
    public ObservableCollection<MenuItemWithCommand> MenuItems { get; }
    
    

    #endregion

 
}