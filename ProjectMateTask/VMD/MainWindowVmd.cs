using ProjectMateTask.Stores.AppInfrastructure.NavigationStores.Base;
using ProjectMateTask.VMD.Base;

namespace ProjectMateTask.VMD;

internal sealed class MainWindowVmd:BaseVmd
{
    private readonly INavigationStore _mainPageNavigationStore;

    public MainWindowVmd(INavigationStore mainPageNavigationStore)
    {
        _mainPageNavigationStore = mainPageNavigationStore;
    }

    public BaseVmd MainPageCurrentVmd => _mainPageNavigationStore.CurrentVmd;

    public BaseVmd MainMenuCurrentVmd => new MainMenuVmd();
}