using System.Windows.Input;
using ProjectMateTask.Infrastructure.CMD.AppInfrastructure;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.CloseNavigationServices;
using ProjectMateTask.VMD.Base;

namespace ProjectMateTask.VMD.Pages.AdditionalPagesVmds.Base;

/// <summary>
///     Базовая реализзация Vmd для доп окон
/// </summary>
internal abstract class BaseAdditionalVmd : BaseVmd, IAdditionalVmd
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

    #region Команды

    public ICommand CloseAdditionalCommand { get; }

    #endregion
}