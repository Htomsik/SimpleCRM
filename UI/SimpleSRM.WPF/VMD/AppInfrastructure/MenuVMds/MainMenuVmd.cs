using System.Collections.ObjectModel;
using MaterialDesignThemes.Wpf;
using SimpleSRM.WPF.Models.AppInfrastructure;
using SimpleSRM.WPF.Services.AppInfrastructure.NavigationServices.Base.TypeNavigationServices;
using SimpleSRM.WPF.VMD.AppInfrastructure.MenuVMds.Base;
using SimpleSRM.WPF.VMD.Pages.Entities.MainEntityVmds;

namespace SimpleSRM.WPF.VMD.AppInfrastructure.MenuVMds;

/// <summary>
///     Vmd для главного меню
/// </summary>
public sealed class MainMenuVmd : BaseMenuNavigationVmd
{
    /// <summary>
    ///     Vmd для главного меню
    /// </summary>
    /// <param name="typeMainEntityNavigationServices">Сервис навигации по MainEntityVmd типам</param>
    public MainMenuVmd(ITypeNavigationServices typeMainEntityNavigationServices) : base(typeMainEntityNavigationServices)
    {
        #region Инициализация свойств

        MenuItems = new ObservableCollection<MenuItemWithCommand>
        {
            new("Менеджеры", PackIconKind.AccountTie, MenuNavigationCommand, typeof(MainManagerVmd)),
            new("Клиенты", PackIconKind.Account, MenuNavigationCommand, typeof(MainClientVmd)),
            new("Продукты", PackIconKind.Shopping, MenuNavigationCommand, typeof(MainProductVmd)),
            new("Статусы клиентов", PackIconKind.Administrator, MenuNavigationCommand, typeof(MainClientStatusVmd)),
            new("Типы продуктов", PackIconKind.FileDocument, MenuNavigationCommand, typeof(MainProductTypeVmd))
        };

        #endregion
    }
    
}