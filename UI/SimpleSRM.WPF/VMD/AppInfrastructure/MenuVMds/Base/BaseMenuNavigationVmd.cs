using System.Collections.Generic;
using System.Windows.Input;
using SimpleSRM.WPF.Infrastructure.CMD.AppInfrastructure;
using SimpleSRM.WPF.Models.AppInfrastructure;
using SimpleSRM.WPF.Services.AppInfrastructure.NavigationServices.Base.TypeNavigationServices;
using SimpleSRM.WPF.VMD.Base;

namespace SimpleSRM.WPF.VMD.AppInfrastructure.MenuVMds.Base;

/// <summary>
///     Базовая реализция меню с навигационными командами
/// </summary>
public class BaseMenuNavigationVmd : BaseVmd, IMenuNavigationVmd
{
    #region Конструкторы

    public BaseMenuNavigationVmd(ITypeNavigationServices typeMainEntityNavigationServices)
    {
        #region Инициализация команд

        MenuNavigationCommand = new TypeNavigationCmd(typeMainEntityNavigationServices);

        #endregion
    }
    
    /// <summary>
    /// Конструктор для тестов
    /// </summary>
    public BaseMenuNavigationVmd()
    {
        
    }

    #endregion
 
    
    public virtual ICollection<MenuItemWithCommand> MenuItems { get; protected set; }
    
    public ICommand MenuNavigationCommand { get; }
}