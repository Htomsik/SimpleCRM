using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.CloseNavigationServices;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores.Base;
using ProjectMateTask.VMD.Pages.Entities.Base;

namespace ProjectMateTask.Services.AppInfrastructure.NavigationServices.CloseNavigationServcies;

/// <summary>
///     Сервис закрытия MainEntityVmd
/// </summary>
internal sealed class CloseMainEntityVmdNavigationServices : BaseCloseNavigationServices<BaseEntityVmd>
{
    public CloseMainEntityVmdNavigationServices(IVmdNavigationStore<BaseEntityVmd> vmdNavigationStore) : base(vmdNavigationStore)
    {
    }
}