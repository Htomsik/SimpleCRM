using ProjectMateTask.Stores.AppInfrastructure.NavigationStores.Base;
using ProjectMateTask.VMD.AppInfrastructure;
using ProjectMateTask.VMD.AppInfrastructure.MenuVMds;
using ProjectMateTask.VMD.AppInfrastructure.MenuVMds.Base;
using ProjectMateTask.VMD.Base;

namespace ProjectMateTask.Stores.AppInfrastructure.NavigationStores;

/// <summary>
///     Навигационное ханилище для главного меню
/// </summary>
public sealed class MainMenuVmdNavigationStore : BaseVmdNavigationStore<BaseMenuNavigationVmd>
{
    public MainMenuVmdNavigationStore(MainMenuVmd? mainMenuVmd)
    {
        CurrentValue = mainMenuVmd;
    }

    /// <summary>
    ///     Конструкто для тестов
    /// </summary>
    public MainMenuVmdNavigationStore()
    {
        
    }
}