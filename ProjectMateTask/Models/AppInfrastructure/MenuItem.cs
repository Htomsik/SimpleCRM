using System;
using MaterialDesignThemes.Wpf;

namespace ProjectMateTask.Models.AppInfrastructure;

/// <summary>
/// Элемент меню
/// </summary>
public class MenuItem
{
    /// <summary>
    /// Имя элемента
    /// </summary>
    public Lazy<string>  Name { get; }

    /// <summary>
    /// Иконпка элемента
    /// </summary>
    public Lazy<PackIconKind>  MaterialIcon { get; }


    /// <summary>
    /// Элемент для составления меню
    /// </summary>
    /// <param name="name">Имя элемента</param>
    /// <param name="materialIconName">Иконка элемента</param>
    public MenuItem(string name, PackIconKind materialIconName)
    {
        Name = new Lazy<string>(()=> name) ;
        
        MaterialIcon= new Lazy<PackIconKind>(()=>materialIconName);
    }
}