using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.NavigationServices;

namespace ProjectMateTask.Models.AppInfrastructure;

internal sealed class MenuItemWithCommand : MenuItem
{
    public ICommand Command { get; }
    public object Parameter { get; }

    public MenuItemWithCommand(string name, PackIconKind materialIconName,ICommand Command,object parameter) : base(name, materialIconName)
    {
        this.Command = Command;
        
        Parameter = parameter;
    }
}