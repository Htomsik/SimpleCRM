using System;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores.Base;
using ProjectMateTask.VMD.Base;

namespace ProjectMateTask.Services.AppInfrastructure.NavigationServices;

internal sealed class MainPageNavigationServices:BaseNavigationServices<BaseVmd>
{
    public MainPageNavigationServices(INavigationStore navigationStore, Func<BaseVmd> createVmd) : base(navigationStore, createVmd){}
  
}