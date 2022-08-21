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
    public ObservableCollection<MainMenuItem> MenuItems { get;}
    
    public MainMenuVmd(INavigationService managersPageNavigationServices,
        INavigationService clientsPageNavigationService,
        INavigationService productsPageNavigationService,
        INavigationService homePageNavigationService,
        INavigationService clientStatusNavigationServices,
        INavigationService productTypeNavigationServices) 
    {
        MenuNavigationCommand = new LambdaCmd(OnMenuNavigationExecute);
        
        MenuItems = new ObservableCollection<MainMenuItem>
        {
            new MainMenuItem("Домашняя страница",PackIconKind.Home,homePageNavigationService),
            new MainMenuItem("Менеджеры",PackIconKind.AccountTie,managersPageNavigationServices),
            new MainMenuItem("Клиенты",PackIconKind.Account,clientsPageNavigationService),
            new MainMenuItem("Продукты",PackIconKind.Shopping,productsPageNavigationService),
            new MainMenuItem("Статусы клиентов",PackIconKind.Administrator,clientStatusNavigationServices),
            new MainMenuItem("Типы продуктов",PackIconKind.FileDocument,productTypeNavigationServices)
        };

    }
    
    public ICommand MenuNavigationCommand { get; set; }

    private void OnMenuNavigationExecute(object navigationService)
    {
        ((INavigationService)navigationService)?.Navigate();
    }
}