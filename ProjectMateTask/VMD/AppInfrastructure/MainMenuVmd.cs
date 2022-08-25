using System.Collections.ObjectModel;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using ProjectMateTask.DAL.Entities.Actors;
using ProjectMateTask.DAL.Entities.Types;
using ProjectMateTask.Infrastructure.CMD;
using ProjectMateTask.Infrastructure.CMD.AppInfrastructure;
using ProjectMateTask.Models.AppInfrastructure;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.NavigationServices;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.TypeNavigationServices;
using ProjectMateTask.VMD.Base;
using ProjectMateTask.VMD.Pages;
using ProjectMateTask.VMD.Pages.EntityVmds;

namespace ProjectMateTask.VMD.AppInfrastructure;

internal sealed class MainMenuVmd:BaseVmd
{
    public ObservableCollection<MenuItemWithCommand> MenuItems { get;}
    
    public MainMenuVmd(ITypeNavigationServices typeNavigationServices)
    {
        MenuNavigationCommand = new TypeNavigationCmd(typeNavigationServices);
        
        MenuItems = new ObservableCollection<MenuItemWithCommand>
        {
            new MenuItemWithCommand("Домашняя страница",PackIconKind.Home,MenuNavigationCommand,typeof(MainPageVmd)),
            new MenuItemWithCommand("Менеджеры",PackIconKind.AccountTie,MenuNavigationCommand,typeof(ManagersVmd)),
            new MenuItemWithCommand("Клиенты",PackIconKind.Account,MenuNavigationCommand,typeof(ClientsVmd)),
            new MenuItemWithCommand("Продукты",PackIconKind.Shopping,MenuNavigationCommand,typeof(ProductsVmd)),
            new MenuItemWithCommand("Статусы клиентов",PackIconKind.Administrator,MenuNavigationCommand,typeof(ClientStatusesVmd)),
            new MenuItemWithCommand("Типы продуктов",PackIconKind.FileDocument,MenuNavigationCommand,typeof(ProductTypeVmd))
        };

    }
    
    public ICommand MenuNavigationCommand { get; }
    
}