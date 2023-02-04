using System.Collections.Generic;
using System.Windows.Input;
using ProjectMateTask.Infrastructure.CMD.AppInfrastructure;
using ProjectMateTask.Models.AppInfrastructure;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.TypeNavigationServices;
using ProjectMateTask.VMD.Base;

namespace ProjectMateTask.VMD.AppInfrastructure.MenuVMds.Base;

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