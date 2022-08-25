using System.Collections.ObjectModel;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using ProjectMateTask.Infrastructure.CMD;
using ProjectMateTask.Models.AppInfrastructure;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.NavigationServices;
using ProjectMateTask.VMD.Base;

namespace ProjectMateTask.VMD.AppInfrastructure;

internal sealed class MainMenuVmd:BaseVmd
{
    public ObservableCollection<MenuItemWithCommand> MenuItems { get;}
    
    public MainMenuVmd(INavigationService managersPageNavigationServices,
        INavigationService clientsPageNavigationService,
        INavigationService productsPageNavigationService,
        INavigationService homePageNavigationService,
        INavigationService clientStatusNavigationServices,
        INavigationService productTypeNavigationServices) 
    {
        MenuNavigationCommand = new LambdaCmd(OnMenuNavigationExecute);
        
        MenuItems = new ObservableCollection<MenuItemWithCommand>
        {
            new MenuItemWithCommand("Домашняя страница",PackIconKind.Home,MenuNavigationCommand,homePageNavigationService),
            new MenuItemWithCommand("Менеджеры",PackIconKind.AccountTie,MenuNavigationCommand,managersPageNavigationServices),
            new MenuItemWithCommand("Клиенты",PackIconKind.Account,MenuNavigationCommand,clientsPageNavigationService),
            new MenuItemWithCommand("Продукты",PackIconKind.Shopping,MenuNavigationCommand,productsPageNavigationService),
            new MenuItemWithCommand("Статусы клиентов",PackIconKind.Administrator,MenuNavigationCommand,clientStatusNavigationServices),
            new MenuItemWithCommand("Типы продуктов",PackIconKind.FileDocument,MenuNavigationCommand,productTypeNavigationServices)
        };

    }
    
    public ICommand MenuNavigationCommand { get; set; }

    private void OnMenuNavigationExecute(object navigationService)
    {
        ((INavigationService)navigationService)?.Navigate();
    }
}