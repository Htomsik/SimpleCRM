using System;
using SimpleSRM.WPF.Stores.AppInfrastructure.NavigationStores.Base;
using SimpleSRM.WPF.VMD.Base;

namespace SimpleSRM.WPF.Services.AppInfrastructure.NavigationServices.Base.CloseNavigationServices;

/// <summary>
///     Базовая релизация сервиса закрытия
/// </summary>
/// <typeparam name="TVmd"></typeparam>
public class BaseCloseNavigationServices<TVmd> : ICloseNavigationServices where TVmd : BaseVmd
{
    private readonly Lazy<IVmdNavigationStore<TVmd>>  _navigationStore;

    /// <summary>
    ///     Конструктор базовой релизации сервиса закрытия
    /// </summary>
    /// <param name="vmdNavigationStore">Навигационное хранилище</param>
    /// <exception cref="ArgumentNullException">Возникает в случае если vmdNavigationStore null</exception>
    public BaseCloseNavigationServices(IVmdNavigationStore<TVmd> vmdNavigationStore)
    {
        _navigationStore =
            new Lazy<IVmdNavigationStore<TVmd>>(vmdNavigationStore) 
            ?? throw new ArgumentNullException(nameof(_navigationStore));
    }
    
    public void Close() => _navigationStore.Value.CurrentValue = null;
    
}