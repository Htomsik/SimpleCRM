using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using SimpleSRM.WPF.Models.AppInfrastructure;

namespace SimpleSRM.WPF.VMD.AppInfrastructure.MenuVMds.Base;

/// <summary>
///     Модель представления для навигационного меню через команды с командами
/// </summary>
public interface IMenuNavigationVmd : INotifyPropertyChanged
{
    /// <summary>
    ///     Коллекция навигационного меню с команандами
    /// </summary>
    public ICollection<MenuItemWithCommand> MenuItems { get; }
    
    /// <summary>
    ///     Команда нав
    /// </summary>
    public ICommand MenuNavigationCommand { get; }
}