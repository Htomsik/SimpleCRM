using ProjectMateTask.Stores.AppInfrastructure.NavigationStores.Base;
using ProjectMateTask.VMD.AppInfrastructure;
using ProjectMateTask.VMD.Base;

namespace ProjectMateTask.Stores.AppInfrastructure.NavigationStores;

/// <summary>
///     Навигационное ханилище для главного меню
/// </summary>
internal class MainMenuNavigationStore : BaseNavigationStore<BaseVmd>
{
    public MainMenuNavigationStore(MainMenuVmd? mainMenuVmd)
    {
        CurrentVmd = mainMenuVmd;
    }
}
