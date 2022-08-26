using ProjectMateTask.Stores.AppInfrastructure.NavigationStores.Base;
using ProjectMateTask.VMD.AppInfrastructure;
using ProjectMateTask.VMD.Base;

namespace ProjectMateTask.Stores.AppInfrastructure.NavigationStores;

/// <summary>
///     Навигационное ханилище для главного меню
/// </summary>
internal class MainMenuVmdNavigationStore : BaseVmdNavigationStore<BaseVmd>
{
    public MainMenuVmdNavigationStore(MainMenuVmd? mainMenuVmd)
    {
        CurrentValue = mainMenuVmd;
    }
}
