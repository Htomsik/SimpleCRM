using System;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores.Base;
using ProjectMateTask.VMD.Base;

namespace ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.TypeNavigationServices;

internal  class BaseTypeNavigationServices<TVmd>:ITypeNavigationServices where TVmd: BaseVmd
{
    private readonly INavigationStore<TVmd> _navigationStore;

    public BaseTypeNavigationServices(INavigationStore<TVmd> navigationStore)
    {
        _navigationStore = navigationStore;
    }
    
    public virtual void Navigate(Type vmdType)
    {
        
        var iocVmd = (TVmd)App.Services.GetService(vmdType);

      _navigationStore.CurrentVmd = iocVmd is not null ? iocVmd 
          : throw new ArgumentNullException($"Отсуствует зарегистрированная Viewmodel для {vmdType}");

    }

    public void Close()
    {
        _navigationStore.CurrentVmd = null;
    }
}