using SimpleSRM.WPF.Stores.AppInfrastructure.NavigationStores.Base;
using SimpleSRM.WPF.VMD.AppInfrastructure.MenuVMds;
using SimpleSRM.WPF.VMD.AppInfrastructure.MenuVMds.Base;

namespace SimpleSRM.WPF.Stores.AppInfrastructure.NavigationStores;

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