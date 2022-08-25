using System;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.NavigationServices;

namespace ProjectMateTask.Models.AppInfrastructure;

internal sealed class MenuItemWithCommand : MenuItem
{
    /// <summary>
    /// указатель на команду для item
    /// </summary>
    public Lazy<ICommand> Command { get; }
    
    /// <summary>
    /// Параметр команды
    /// </summary>
    public Lazy<object> Parameter { get; }
    
    /// <summary>
    /// Элемент меню с командной
    /// </summary>
    /// <param name="name">Имя элемента</param>
    /// <param name="materialIconName">Иконка элемента</param>
    /// <param name="command">Команда, используемая при взаимодейтсвии с элементом</param>
    /// <param name="CmdParameter">Параметр для команды</param>
    public MenuItemWithCommand(string name, PackIconKind materialIconName, ICommand command, object CmdParameter) : base(
        name, materialIconName)
    {
        Command = new Lazy<ICommand>(()=> command);
        
        Parameter = new Lazy<object>(()=> CmdParameter);
        
    }
}