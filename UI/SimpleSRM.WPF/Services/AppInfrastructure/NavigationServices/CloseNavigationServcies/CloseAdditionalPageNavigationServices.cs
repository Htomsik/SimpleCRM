using SimpleSRM.WPF.Services.AppInfrastructure.NavigationServices.Base.CloseNavigationServices;
using SimpleSRM.WPF.Stores.AppInfrastructure.NavigationStores.Base;
using SimpleSRM.WPF.VMD.Pages.AdditionalPagesVmds.Base;

namespace SimpleSRM.WPF.Services.AppInfrastructure.NavigationServices.CloseNavigationServcies;

/// <summary>
///     Сервис закрытия допольнительного окна
/// </summary>
public sealed class CloseAdditionalPageNavigationServices : BaseCloseNavigationServices<BaseAdditionalVmd>
{
    public CloseAdditionalPageNavigationServices(IVmdNavigationStore<BaseAdditionalVmd> vmdNavigationStore) : base(vmdNavigationStore)
    {
    }
}