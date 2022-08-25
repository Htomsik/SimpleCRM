using ProjectMateTask.Stores.AppInfrastructure.NavigationStores.Base;
using ProjectMateTask.VMD.Pages;
using ProjectMateTask.VMD.Pages.Entities.MainEntityVmds.Base;

namespace ProjectMateTask.Stores.AppInfrastructure.NavigationStores;

/// <summary>
///     Навигационное ханилище для Entity страниц
/// </summary>
internal sealed class MainEntityNavigationStore : BaseNavigationStore<BaseNotGenericEntityVmd>
{
    public MainEntityNavigationStore()
    {
        CurrentVmd = (BaseNotGenericEntityVmd?)App.Services.GetService(typeof(MainPageVmd));
    }
}
