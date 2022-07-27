using ProjectMateTask.Stores.AppInfrastructure.NavigationStores.Base;
using ProjectMateTask.VMD.Base;

namespace ProjectMateTask.VMD;

internal sealed class MainWindowVmd:BaseVmd
{
    private readonly INavigationStore _mainPageNavigationStore;
    
    private readonly INavigationStore _mainMenuNavigationStore;

    public MainWindowVmd(INavigationStore mainPageNavigationStore, INavigationStore mainMenuNavigationStore)
    {
        _mainPageNavigationStore = mainPageNavigationStore;
        _mainMenuNavigationStore = mainMenuNavigationStore;
    }

    public BaseVmd MainPageCurrentVmd => _mainPageNavigationStore.CurrentVmd;

    public BaseVmd MainMenuCurrentVmd => _mainMenuNavigationStore.CurrentVmd;
}