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
    public ObservableCollection<MenuNavigationServiceItem> MenuItems { get;}
    
    public MainMenuVmd(INavigationService managersPageNavigationServices,
        INavigationService clientsPageNavigationService,
        INavigationService productsPageNavigationService,
        INavigationService homePageNavigationService,
        INavigationService clientStatusNavigationServices,
        INavigationService productTypeNavigationServices) 
    {
        MenuNavigationCommand = new LambdaCmd(OnMenuNavigationExecute);
        
        MenuItems = new ObservableCollection<MenuNavigationServiceItem>
        {
            new MenuNavigationServiceItem("Домашняя страница",PackIconKind.Home,homePageNavigationService),
            new MenuNavigationServiceItem("Менеджеры",PackIconKind.AccountTie,managersPageNavigationServices),
            new MenuNavigationServiceItem("Клиенты",PackIconKind.Account,clientsPageNavigationService),
            new MenuNavigationServiceItem("Продукты",PackIconKind.Shopping,productsPageNavigationService),
            new MenuNavigationServiceItem("Статусы клиентов",PackIconKind.Administrator,clientStatusNavigationServices),
            new MenuNavigationServiceItem("Типы продуктов",PackIconKind.FileDocument,productTypeNavigationServices)
        };

    }
    
    public ICommand MenuNavigationCommand { get; set; }

    private void OnMenuNavigationExecute(object navigationService)
    {
        ((INavigationService)navigationService)?.Navigate();
    }
}