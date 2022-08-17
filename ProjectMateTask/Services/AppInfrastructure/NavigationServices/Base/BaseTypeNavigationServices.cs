using System;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores.Base;
using ProjectMateTask.VMD.Base;

namespace ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base;

internal class BaseTypeNavigationServices:ITypeNavigationServices
{
    private readonly INavigationStore _navigationStore;

    public BaseTypeNavigationServices(INavigationStore navigationStore)
    {
        _navigationStore = navigationStore;
    }
    
    public virtual void Navigate(Type vmdType)
    {
        
        var iocVmd = (BaseVmd)App.Services.GetService(vmdType);

      _navigationStore.CurrentVmd = iocVmd is not null ? iocVmd 
          : throw new ArgumentNullException($"Отсуствует зарегистрированная Viewmodel для {vmdType}");

    }

    public void Close()
    {
        _navigationStore.CurrentVmd = null;
    }
}