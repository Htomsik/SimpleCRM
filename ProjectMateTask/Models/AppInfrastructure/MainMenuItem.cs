using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using ProjectMateTask.Infrastructure.CMD;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base;

namespace ProjectMateTask.Models.AppInfrastructure;

public sealed class MainMenuItem
{
    public  string Name { get; }

    public  PackIconKind MaterialIcon { get; }

    public  INavigationService NavigationService { get;  }

    public MainMenuItem(string name, PackIconKind materialIconName,INavigationService navigationService)
    {
        Name = name;
        
        MaterialIcon= materialIconName;
        
        NavigationService = navigationService;
    }
   
}