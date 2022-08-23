using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.CloseNavigationServices;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores.Base;
using ProjectMateTask.VMD.Pages.AdditionalPagesVmds.Base;

namespace ProjectMateTask.Services.AppInfrastructure.NavigationServices;

internal sealed class CloseAdditionalPageNavigationServices : BaseCloseNavigationServices<BaseAdditionalVmd>
{
    public CloseAdditionalPageNavigationServices(INavigationStore<BaseAdditionalVmd> navigationStore) : base(navigationStore)
    {
    }
}