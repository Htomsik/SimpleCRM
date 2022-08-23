using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using ProjectMateTask.Infrastructure.CMD;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.NavigationServices;

namespace ProjectMateTask.Models.AppInfrastructure;

internal class MenuNavigationServiceItem : MenuItem
{
    public  INavigationService NavigationService { get;  }

    public MenuNavigationServiceItem(string name, PackIconKind materialIconName,INavigationService navigationService) : base(name,materialIconName)
    {
        NavigationService = navigationService;
    }
   
}