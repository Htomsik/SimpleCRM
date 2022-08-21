using System;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.NavigationServices;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores.Base;
using ProjectMateTask.VMD.Base;
using ProjectMateTask.VMD.Pages.AdditionalPages.Base;

namespace ProjectMateTask.Services.AppInfrastructure.NavigationServices;

internal sealed  class AdditionalPageNavigationService : BaseNavigationServices<BaseAdditionalVmd>
{
    public AdditionalPageNavigationService(INavigationStore<BaseAdditionalVmd> navigationStore, Func<BaseAdditionalVmd> createVmd) : base(navigationStore, createVmd)
    {
    }
}