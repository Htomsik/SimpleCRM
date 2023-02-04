using System.Collections.ObjectModel;
using MaterialDesignThemes.Wpf;
using ProjectMateTask.Models.AppInfrastructure;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.TypeNavigationServices;
using ProjectMateTask.VMD.AppInfrastructure.MenuVMds.Base;
using ProjectMateTask.VMD.Pages.Entities.MainEntityVmds;

namespace ProjectMateTask.VMD.AppInfrastructure.MenuVMds;

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