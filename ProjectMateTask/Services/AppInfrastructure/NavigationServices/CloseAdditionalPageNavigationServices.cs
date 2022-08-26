using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.CloseNavigationServices;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores.Base;
using ProjectMateTask.VMD.Pages.AdditionalPagesVmds.Base;

namespace ProjectMateTask.Services.AppInfrastructure.NavigationServices;

/// <summary>
///     Сервис закрытия допольнительного окна
/// </summary>
internal sealed class CloseAdditionalPageNavigationServices : BaseCloseNavigationServices<BaseAdditionalVmd>
{
    public CloseAdditionalPageNavigationServices(IVmdNavigationStore<BaseAdditionalVmd> vmdNavigationStore) : base(vmdNavigationStore)
    {
    }
}