using ProjectMateTask.Stores.AppInfrastructure.NavigationStores.Base;
using ProjectMateTask.VMD;
using ProjectMateTask.VMD.AppInfrastructure;
using ProjectMateTask.VMD.Base;

namespace ProjectMateTask.Stores.AppInfrastructure.NavigationStores;

internal class MainMenuNavigationStore : BaseNavigationStore<BaseVmd>
{
    public MainMenuNavigationStore(MainMenuVmd? mainMenuVmd)
    {
        CurrentVmd = mainMenuVmd;
    }
}
