using System;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores.Base;
using ProjectMateTask.VMD.Base;

namespace ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base;

internal abstract class BaseNavigationServices<TVmd>:INavigationService where TVmd : BaseVmd
{
    protected readonly INavigationStore _navigationStore;
    
    protected readonly Func<TVmd> _createVmd;

    public BaseNavigationServices(INavigationStore navigationStore, Func<TVmd> createVmd)
    {
        _navigationStore = navigationStore;
        
        _createVmd = createVmd;
    }
    
    public virtual void Navigate()
    {
        _navigationStore.CurrentVmd = _createVmd();
    }
}