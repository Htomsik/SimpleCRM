using System;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.NavigationServices;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.TypeNavigationServices;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores.Base;
using ProjectMateTask.VMD.Pages.Entities.MainEntityVmds.Base;

namespace ProjectMateTask.Services.AppInfrastructure.NavigationServices;

/// <summary>
///     Сервис навигации между Entity страницами
/// </summary>
internal sealed class MainEntityStoreTypeNavigationService:BaseTypeNavigationServices<BaseNotGenericEntityVmd>
{
    public MainEntityStoreTypeNavigationService(INavigationStore<BaseNotGenericEntityVmd> navigationStore) : base(navigationStore)
    {
    }
}