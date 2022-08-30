using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.CloseNavigationServices;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores.Base;
using ProjectMateTask.VMD.Pages.AdditionalPagesVmds.Base;

namespace ProjectMateTask.Services.AppInfrastructure.NavigationServices.CloseNavigationServcies;

/// <summary>
///     Сервис закрытия допольнительного окна
/// </summary>
public sealed class CloseAdditionalPageNavigationServices : BaseCloseNavigationServices<BaseAdditionalVmd>
{
    public CloseAdditionalPageNavigationServices(IVmdNavigationStore<BaseAdditionalVmd> vmdNavigationStore) : base(vmdNavigationStore)
    {
    }
}