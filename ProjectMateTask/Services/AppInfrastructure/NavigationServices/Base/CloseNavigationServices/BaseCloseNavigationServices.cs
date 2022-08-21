using ProjectMateTask.Stores.AppInfrastructure.NavigationStores.Base;
using ProjectMateTask.VMD.Base;

namespace ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.CloseNavigationServices;

internal abstract class BaseCloseNavigationServices<TVmd> : ICloseNavigationServices where TVmd : BaseVmd
{
    private readonly INavigationStore<TVmd> _navigationStore;

    public BaseCloseNavigationServices(INavigationStore<TVmd> navigationStore)
    {
        _navigationStore = navigationStore;
    }
    
    public void Close() => _navigationStore.CurrentVmd = null;
    
}