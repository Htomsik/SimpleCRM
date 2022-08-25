using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using ProjectMateTask.Infrastructure.CMD;
using ProjectMateTask.Infrastructure.CMD.AppInfrastructure;
using ProjectMateTask.Models.AppInfrastructure;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.TypeNavigationServices;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores.Base;
using ProjectMateTask.VMD.Base;
using ProjectMateTask.VMD.Pages.AdditionalPagesVmds.Base;
using ProjectMateTask.VMD.Pages.SettingsVmds;

namespace ProjectMateTask.VMD.Pages.AdditionalPagesVmds;

internal sealed class SettingsAdditionalPageVmd : BaseAdditionalVmd
{
    private readonly INavigationStore<BaseVmd> _localNavigationStore;

    private ITypeNavigationServices _typeNavigationServices;

    public ObservableCollection<MenuItemWithCommand> MenuItems { get;}

    public SettingsAdditionalPageVmd(CloseAdditionalPageNavigationServices closeAdditionalNavigationService) : base(closeAdditionalNavigationService)
    {
        _localNavigationStore = new BaseNavigationStore<BaseVmd>();

        _localNavigationStore.CurrentVmdChanged += () => OnPropertyChanged(nameof(CurrentSettingsPageVmd));

        
        _typeNavigationServices = new BaseTypeNavigationServices<BaseVmd>(_localNavigationStore);

        MenuNavigationCommand = new TypeNavigationCmd(_typeNavigationServices);
        
        MenuItems = new ObservableCollection<MenuItemWithCommand>
        {
            new MenuItemWithCommand("О программе",PackIconKind.Home,MenuNavigationCommand,typeof(AboutProgramVmd)),
        };

       
    }


    public BaseVmd CurrentSettingsPageVmd => _localNavigationStore.CurrentVmd;
    
    
    public ICommand MenuNavigationCommand { get; }

  
    

}