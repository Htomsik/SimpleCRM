using System.Collections.ObjectModel;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using ProjectMateTask.Infrastructure.CMD;
using ProjectMateTask.Models.AppInfrastructure;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base;
using ProjectMateTask.VMD.Base;

namespace ProjectMateTask.VMD.AppInfrastructure;

public class MainMenuVmd:BaseVmd
{
    public ObservableCollection<MainMenuItem> MenuItems { get;}
    
    public MainMenuVmd(INavigationService ManagersPageNavigationServices,
        INavigationService ClientsPageNavigationService,
        INavigationService ProductsPageNavigationService,
        INavigationService HomePageNavigationService,
        INavigationService ClientStatusesNavigationServices) 
    {
        MenuNavigationCommand = new LambdaCmd(OnMenuNavigationExecute);
        
        MenuItems = new ObservableCollection<MainMenuItem>
        {
            new MainMenuItem("Домашняя страниц",PackIconKind.Home,HomePageNavigationService),
            new MainMenuItem("Managers",PackIconKind.AccountTie,ManagersPageNavigationServices),
            new MainMenuItem("Clients",PackIconKind.Account,ClientsPageNavigationService),
            new MainMenuItem("Products",PackIconKind.Shopping,ProductsPageNavigationService),
            new MainMenuItem("Статусы клиентов",PackIconKind.Administrator,ClientStatusesNavigationServices)
        };

    }
    
    public ICommand MenuNavigationCommand { get; set; }

    private void OnMenuNavigationExecute(object navigationService)
    {
        ((INavigationService)navigationService)?.Navigate();
    }
}