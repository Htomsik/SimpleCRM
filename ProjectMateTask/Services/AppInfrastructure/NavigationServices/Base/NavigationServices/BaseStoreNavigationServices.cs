using System;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores.Base;
using ProjectMateTask.VMD.Base;

namespace ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.NavigationServices;

internal abstract class BaseStoreNavigationServices<TVmd>:INavigationService where TVmd : BaseVmd
{
    protected readonly INavigationStore<TVmd> _navigationStore;
    
    protected readonly Func<TVmd> _createVmd;

    public BaseStoreNavigationServices(INavigationStore<TVmd> navigationStore, Func<TVmd> createVmd)
    {
        _navigationStore = navigationStore;
        
        _createVmd = createVmd;
    }
    
    public virtual void Navigate()
    {
        _navigationStore.CurrentVmd = _createVmd();
    }

    public void Close()
    {
        _navigationStore.CurrentVmd = null;
    }
}

