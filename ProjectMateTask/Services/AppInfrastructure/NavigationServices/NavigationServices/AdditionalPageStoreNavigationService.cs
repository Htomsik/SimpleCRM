using System;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.NavigationServices;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores.Base;
using ProjectMateTask.VMD.Pages.AdditionalPagesVmds.Base;

namespace ProjectMateTask.Services.AppInfrastructure.NavigationServices.NavigationServices;

/// <summary>
///     Сервис навигации по дополнительным окнам
/// </summary>
public sealed  class AdditionalPageStoreNavigationService : BaseStoreNavigationServices<BaseAdditionalVmd>
{
    public AdditionalPageStoreNavigationService(IVmdNavigationStore<BaseAdditionalVmd> vmdNavigationStore, Func<BaseAdditionalVmd> createVmd) : base(vmdNavigationStore, createVmd)
    {
    }
}