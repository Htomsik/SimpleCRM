using System;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores.Base;
using ProjectMateTask.VMD.Base;

namespace ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.NavigationServices;

/// <summary>
///     Базовая реализация навигации с навигационными хринилищами
/// </summary>
/// <typeparam name="TVmd">Любой тип, наследуемый от BaseVmd</typeparam>
internal abstract class BaseStoreNavigationServices<TVmd>:INavigationService where TVmd : BaseVmd
{
    protected readonly Lazy<INavigationStore<TVmd>>  NavigationStore;
    
    protected readonly Lazy<Func<TVmd>> CreateVmd;

    /// <summary>
    ///      Базовая реализация навигации с навигационными хринилищами
    /// </summary>
    /// <param name="navigationStore">Навигационное хранилище</param>
    /// <param name="createVmd">Vmd передаваемое в навигационное хранилище</param>
    /// <exception cref="ArgumentNullException">Возникает в случае если navigationStore или createVmd null  </exception>
    public BaseStoreNavigationServices(INavigationStore<TVmd> navigationStore, Func<TVmd> createVmd)
    {
        NavigationStore = 
            new Lazy<INavigationStore<TVmd>>(()=>navigationStore) 
            ?? throw new ArgumentNullException(nameof(NavigationStore));
        
        CreateVmd = 
            new Lazy<Func<TVmd>>(()=>createVmd) 
            ?? throw new ArgumentNullException(nameof(CreateVmd));
    }
    
    public virtual void Navigate() => NavigationStore.Value.CurrentVmd = CreateVmd.Value();

    public virtual void Close() => NavigationStore.Value.CurrentVmd = null;
 
}

