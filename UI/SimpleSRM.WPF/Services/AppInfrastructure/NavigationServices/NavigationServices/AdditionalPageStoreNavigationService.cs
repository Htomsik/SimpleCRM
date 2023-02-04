using System;
using SimpleSRM.WPF.Services.AppInfrastructure.NavigationServices.Base.NavigationServices;
using SimpleSRM.WPF.Stores.AppInfrastructure.NavigationStores.Base;
using SimpleSRM.WPF.VMD.Pages.AdditionalPagesVmds.Base;

namespace SimpleSRM.WPF.Services.AppInfrastructure.NavigationServices.NavigationServices;

/// <summary>
///     Сервис навигации по дополнительным окнам
/// </summary>
public sealed  class AdditionalPageStoreNavigationService : BaseStoreNavigationServices<BaseAdditionalVmd>
{
    public AdditionalPageStoreNavigationService(IVmdNavigationStore<BaseAdditionalVmd> vmdNavigationStore, Func<BaseAdditionalVmd> createVmd) : base(vmdNavigationStore, createVmd)
    {
    }
}