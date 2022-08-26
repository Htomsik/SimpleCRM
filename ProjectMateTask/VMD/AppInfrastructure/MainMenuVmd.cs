using System.Collections.ObjectModel;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using ProjectMateTask.Infrastructure.CMD.AppInfrastructure;
using ProjectMateTask.Models.AppInfrastructure;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.TypeNavigationServices;
using ProjectMateTask.VMD.Base;
using ProjectMateTask.VMD.Pages;
using ProjectMateTask.VMD.Pages.Entities.MainEntityVmds;

namespace ProjectMateTask.VMD.AppInfrastructure;

/// <summary>
///     Vmd для главного меню
/// </summary>
internal sealed class MainMenuVmd : BaseVmd
{
    public MainMenuVmd(ITypeNavigationServices typeNavigationServices)
    {
        MenuNavigationCommand = new TypeNavigationCmd(typeNavigationServices);

        MenuItems = new ObservableCollection<MenuItemWithCommand>
        {
            new("Менеджеры", PackIconKind.AccountTie, MenuNavigationCommand, typeof(ManagersVmd)),
            new("Клиенты", PackIconKind.Account, MenuNavigationCommand, typeof(ClientsVmd)),
            new("Продукты", PackIconKind.Shopping, MenuNavigationCommand, typeof(ProductsVmd)),
            new("Статусы клиентов", PackIconKind.Administrator, MenuNavigationCommand, typeof(ClientStatusesVmd)),
            new("Типы продуктов", PackIconKind.FileDocument, MenuNavigationCommand, typeof(ProductTypeVmd))
        };
    }

    /// <summary>
    ///     Коллекцию для меню
    /// </summary>
    public ObservableCollection<MenuItemWithCommand> MenuItems { get; }

    /// <summary>
    ///         Команда навигации между страницами
    /// </summary>
    public ICommand MenuNavigationCommand { get; }
}