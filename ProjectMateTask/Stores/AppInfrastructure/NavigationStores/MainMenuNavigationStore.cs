using ProjectMateTask.Stores.AppInfrastructure.NavigationStores.Base;
using ProjectMateTask.VMD;
using ProjectMateTask.VMD.AppInfrastructure;

namespace ProjectMateTask.Stores.AppInfrastructure.NavigationStores;

internal class MainMenuNavigationStore : BaseNavigationStore
{
    public MainMenuNavigationStore(MainMenuVmd? mainMenuVmd)
    {
        CurrentVmd = mainMenuVmd;
    }
}
