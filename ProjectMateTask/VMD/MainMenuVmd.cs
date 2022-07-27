using System.Collections.ObjectModel;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using ProjectMateTask.Infrastructure.CMD;
using ProjectMateTask.Models.AppInfrastructure;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base;
using ProjectMateTask.VMD.Base;

namespace ProjectMateTask.VMD;

public class MainMenuVmd:BaseVmd
{
    public ObservableCollection<MainMenuItem> MenuItems { get;}
    
    public MainMenuVmd(INavigationService ManagersPageNavigationServices,INavigationService ClientsPageNavigationService)
    {
        MenuNavigationCommand = new LambdaCmd(OnMenuNavigationExecute);
        
        MenuItems = new ObservableCollection<MainMenuItem>
        {
            new MainMenuItem("Managers",PackIconKind.Account,ManagersPageNavigationServices),
            new MainMenuItem("Clients",PackIconKind.AccountTie,ClientsPageNavigationService)
        };

    }
    
    public ICommand MenuNavigationCommand { get; set; }

    private void OnMenuNavigationExecute(object navigationService)
    {
        ((INavigationService)navigationService)?.Navigate();
    }
}