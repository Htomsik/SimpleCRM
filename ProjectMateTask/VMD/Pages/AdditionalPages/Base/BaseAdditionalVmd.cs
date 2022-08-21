using System.Windows.Input;
using ProjectMateTask.Infrastructure.CMD.AppInfrastructure;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.CloseNavigationServices;
using ProjectMateTask.VMD.Base;

namespace ProjectMateTask.VMD.Pages.AdditionalPages.Base;

internal abstract class BaseAdditionalVmd:BaseVmd
{
    public BaseAdditionalVmd(ICloseNavigationServices closeAdditionalNavigationService)
    {
        CloseAdditionalCommand = new CloseNavigationCmd(closeAdditionalNavigationService);
    }
    
    /// <summary>
    /// Команда закрытия модального окна
    /// </summary>
    public ICommand CloseAdditionalCommand { get; }
}