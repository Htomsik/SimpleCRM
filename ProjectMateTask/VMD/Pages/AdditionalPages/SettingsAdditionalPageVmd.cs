using ProjectMateTask.Services.AppInfrastructure.NavigationServices;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.CloseNavigationServices;
using ProjectMateTask.VMD.Base;
using ProjectMateTask.VMD.Pages.AdditionalPages.Base;

namespace ProjectMateTask.VMD.Pages.AdditionalPages;

internal sealed class SettingsAdditionalPageVmd : BaseAdditionalVmd
{
    public SettingsAdditionalPageVmd(CloseAdditionalPageNavigationServices closeAdditionalNavigationService) : base(closeAdditionalNavigationService)
    {
    }
}