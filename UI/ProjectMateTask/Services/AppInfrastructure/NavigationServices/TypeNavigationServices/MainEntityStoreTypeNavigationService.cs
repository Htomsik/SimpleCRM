using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.TypeNavigationServices;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores.Base;
using ProjectMateTask.VMD.Pages.Entities.Base;

namespace ProjectMateTask.Services.AppInfrastructure.NavigationServices.TypeNavigationServices;

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