using System;
using SimpleSRM.WPF.Stores.AppInfrastructure.NavigationStores.Base;
using SimpleSRM.WPF.VMD.Base;

namespace SimpleSRM.WPF.Services.AppInfrastructure.NavigationServices.Base.NavigationServices;

/// <summary>
///     Базовая реализация навигации с навигационными хринилищами
/// </summary>
/// <typeparam name="TVmd">Любой тип, наследуемый от BaseVmd</typeparam>
public class BaseStoreNavigationServices<TVmd>:INavigationService where TVmd : BaseVmd
{
    protected readonly Lazy<IVmdNavigationStore<TVmd>>  NavigationStore;
    
    protected readonly Lazy<Func<TVmd>> CreateVmd;

    /// <summary>
    ///      Базовая реализация навигации с навигационными хринилищами
    /// </summary>
    /// <param name="vmdNavigationStore">Навигационное хранилище</param>
    /// <param name="createVmd">Vmd передаваемое в навигационное хранилище</param>
    /// <exception cref="ArgumentNullException">Возникает в случае если vmdNavigationStore или createVmd null  </exception>
    public BaseStoreNavigationServices(IVmdNavigationStore<TVmd> vmdNavigationStore, Func<TVmd> createVmd)
    {
        NavigationStore = 
            new Lazy<IVmdNavigationStore<TVmd>>(()=>vmdNavigationStore) 
            ?? throw new ArgumentNullException(nameof(NavigationStore));
        
        CreateVmd = 
            new Lazy<Func<TVmd>>(()=>createVmd) 
            ?? throw new ArgumentNullException(nameof(CreateVmd));
    }
    
    public virtual void Navigate() => NavigationStore.Value.CurrentValue = CreateVmd.Value();

    public virtual void Close() => NavigationStore.Value.CurrentValue = null;
 
}

