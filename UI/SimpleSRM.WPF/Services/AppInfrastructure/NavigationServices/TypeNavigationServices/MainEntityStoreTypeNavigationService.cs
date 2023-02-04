using SimpleSRM.WPF.Services.AppInfrastructure.NavigationServices.Base.TypeNavigationServices;
using SimpleSRM.WPF.Stores.AppInfrastructure.NavigationStores.Base;
using SimpleSRM.WPF.VMD.Pages.Entities.Base;

namespace SimpleSRM.WPF.Services.AppInfrastructure.NavigationServices.TypeNavigationServices;

/// <summary>
///     Сервис навигации между Entity страницами
/// </summary>
internal sealed class MainEntityStoreTypeNavigationService : BaseTypeNavigationServices<BaseEntityVmd>
{
    public MainEntityStoreTypeNavigationService(IVmdNavigationStore<BaseEntityVmd> vmdNavigationStore) : base(
        vmdNavigationStore)
    {
    }
}