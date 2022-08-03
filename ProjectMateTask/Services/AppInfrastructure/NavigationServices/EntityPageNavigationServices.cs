using System;
using ProjectMateTask.DAL.Entities.Actors;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores.Base;
using ProjectMateTask.VMD.Base;

namespace ProjectMateTask.Services.AppInfrastructure.NavigationServices;

internal sealed class EntityPageNavigationServices: BaseNavigationServices<BaseVmd>
{
    public EntityPageNavigationServices(INavigationStore navigationStore, Func<BaseVmd> createVmd) : base(navigationStore, createVmd)
    {
    }
    
}