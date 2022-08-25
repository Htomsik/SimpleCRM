using System;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores.Base;
using ProjectMateTask.VMD.Base;

namespace ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.CloseNavigationServices;

/// <summary>
///     Базовая релизация сервиса закрытия
/// </summary>
/// <typeparam name="TVmd"></typeparam>
internal abstract class BaseCloseNavigationServices<TVmd> : ICloseNavigationServices where TVmd : BaseVmd
{
    private readonly Lazy<INavigationStore<TVmd>>  _navigationStore;

    /// <summary>
    ///     Конструктор базовой релизации сервиса закрытия
    /// </summary>
    /// <param name="navigationStore">Навигационное хранилище</param>
    /// <exception cref="ArgumentNullException">Возникает в случае если navigationStore null</exception>
    public BaseCloseNavigationServices(INavigationStore<TVmd> navigationStore)
    {
        _navigationStore =
            new Lazy<INavigationStore<TVmd>>(navigationStore) 
            ?? throw new ArgumentNullException(nameof(_navigationStore));
    }
    
    public void Close() => _navigationStore.Value.CurrentVmd = null;
    
}