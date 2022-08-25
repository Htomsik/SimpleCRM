using System;
using ProjectMateTask.DAL.Entities.Actors;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.NavigationServices;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores.Base;
using ProjectMateTask.VMD.Base;
using ProjectMateTask.VMD.Pages.EntityVmds;
using ProjectMateTask.VMD.Pages.EntityVmds.Base;

namespace ProjectMateTask.Services.AppInfrastructure.NavigationServices;

internal sealed class MainEntityPageStoreNavigationService:BaseStoreNavigationServices<BaseNotGenericEntityVmd>
{
    public MainEntityPageStoreNavigationService(INavigationStore<BaseNotGenericEntityVmd> navigationStore, Func<BaseNotGenericEntityVmd> createVmd) : base(navigationStore, createVmd)
    {
    }
}