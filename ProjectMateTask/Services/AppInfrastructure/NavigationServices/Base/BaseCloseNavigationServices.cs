using ProjectMateTask.Stores.AppInfrastructure.NavigationStores.Base;

namespace ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base;

internal class BaseCloseNavigationServices : ICloseNavigationServices
{
    private readonly INavigationStore _navigationStore;

    public BaseCloseNavigationServices(INavigationStore navigationStore)
    {
        _navigationStore = navigationStore;
    }
    
    public void Close() => _navigationStore.CurrentVmd = null;
    
}