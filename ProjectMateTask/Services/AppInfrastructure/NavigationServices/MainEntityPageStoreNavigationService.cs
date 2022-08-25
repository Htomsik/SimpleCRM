using System;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.NavigationServices;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores.Base;
using ProjectMateTask.VMD.Pages.EntityVmds.Base;

namespace ProjectMateTask.Services.AppInfrastructure.NavigationServices;

/// <summary>
///     Сервис навигации между Entity страницами
/// </summary>
internal sealed class MainEntityPageStoreNavigationService:BaseStoreNavigationServices<BaseNotGenericEntityVmd>
{
    public MainEntityPageStoreNavigationService(INavigationStore<BaseNotGenericEntityVmd> navigationStore, Func<BaseNotGenericEntityVmd> createVmd) : base(navigationStore, createVmd)
    {
    }
}