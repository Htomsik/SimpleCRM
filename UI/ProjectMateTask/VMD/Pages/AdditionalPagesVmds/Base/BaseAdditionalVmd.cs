using System.Windows.Input;
using ProjectMateTask.Infrastructure.CMD.AppInfrastructure;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.CloseNavigationServices;
using ProjectMateTask.VMD.Base;

namespace ProjectMateTask.VMD.Pages.AdditionalPagesVmds.Base;

/// <summary>
///     Базовая реализзация Vmd для доп окон
/// </summary>
public class BaseAdditionalVmd : BaseVmd, IAdditionalVmd
{
    /// <summary>
    ///     Сервис закрытия доп окна
    /// </summary>
    /// <param name="closeAdditionalNavigationService">Навигационный сервис закрытия доп окна</param>
    public BaseAdditionalVmd(ICloseNavigationServices closeAdditionalNavigationService)
    {
        #region Инициализация команд

        CloseAdditionalCommand = new CloseNavigationCmd(closeAdditionalNavigationService);

        #endregion
    }

    /// <summary>
    ///     Конструктор для тестов
    /// </summary>
    public BaseAdditionalVmd()
    {
        
    }

    #region Команды

    public ICommand CloseAdditionalCommand { get; }

    #endregion
}