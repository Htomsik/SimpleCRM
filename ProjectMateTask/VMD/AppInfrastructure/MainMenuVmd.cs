using System.Collections.ObjectModel;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using ProjectMateTask.Infrastructure.CMD.AppInfrastructure;
using ProjectMateTask.Models.AppInfrastructure;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.TypeNavigationServices;
using ProjectMateTask.VMD.Base;
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
            new("Менеджеры", PackIconKind.AccountTie, MenuNavigationCommand, typeof(ManagersVmdVmd)),
            new("Клиенты", PackIconKind.Account, MenuNavigationCommand, typeof(ClientsVmdVmd)),
            new("Продукты", PackIconKind.Shopping, MenuNavigationCommand, typeof(ProductsVmdVmd)),
            new("Статусы клиентов", PackIconKind.Administrator, MenuNavigationCommand, typeof(ClientStatusesVmdVmd)),
            new("Типы продуктов", PackIconKind.FileDocument, MenuNavigationCommand, typeof(ProductTypeVmdVmd))
        };
    }

    /// <summary>
    ///     Коллекцию навигационного меню
    /// </summary>
    public ObservableCollection<MenuItemWithCommand> MenuItems { get; }

    /// <summary>
    ///     Команда навигации между страницами
    /// </summary>
    public ICommand MenuNavigationCommand { get; }
}