using SimpleSRM.WPF.Services.AppInfrastructure.NavigationServices.Base.CloseNavigationServices;
using SimpleSRM.WPF.Stores.AppInfrastructure.NavigationStores.Base;
using SimpleSRM.WPF.VMD.Pages.Entities.Base;

namespace SimpleSRM.WPF.Services.AppInfrastructure.NavigationServices.CloseNavigationServcies;

/// <summary>
///     Сервис закрытия MainEntityVmd
/// </summary>
public sealed class CloseMainEntityVmdNavigationServices : BaseCloseNavigationServices<BaseEntityVmd>
{
    public CloseMainEntityVmdNavigationServices(IVmdNavigationStore<BaseEntityVmd> vmdNavigationStore) : base(vmdNavigationStore)
    {
    }
}