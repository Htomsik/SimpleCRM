using System.Windows.Input;
using ProjectMateTask.Infrastructure.CMD.AppInfrastructure;
using ProjectMateTask.Infrastructure.MessageBuses;
using ProjectMateTask.Infrastructure.MessageBuses.Base;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.NavigationServices;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores.Base;
using ProjectMateTask.VMD.Base;
using ProjectMateTask.VMD.Pages.AdditionalPagesVmds.Base;
using ProjectMateTask.VMD.Pages.Entities.Base;
using ProjectMateTask.VMD.Pages.Entities.MainEntityVmds.Base;

namespace ProjectMateTask.VMD.AppInfrastructure;

internal sealed class MainWindowVmd:BaseVmd
{
    private readonly IEntityVmdNavigationStore<BaseEntityVmd> _mainPageVmdNavigationStore;
    
    private readonly IVmdNavigationStore<BaseVmd> _mainMenuVmdNavigationStore;
    
    private readonly IVmdNavigationStore<BaseAdditionalVmd> _additionalVmdNavigationStore;

    public MainWindowVmd(IEntityVmdNavigationStore<BaseEntityVmd> mainPageVmdNavigationStore,
        IVmdNavigationStore<BaseVmd> mainMenuVmdNavigationStore,
        IVmdNavigationStore<BaseAdditionalVmd> additionalVmdNavigationStore,
        INavigationService openSettingsNavigationServices, 
        IMessageBus<string> loggerMessageBus)
    {
        _mainPageVmdNavigationStore = mainPageVmdNavigationStore;
        
        _mainMenuVmdNavigationStore = mainMenuVmdNavigationStore;
        
        _additionalVmdNavigationStore = additionalVmdNavigationStore;

        OpenSettingsCommand = new NavigationCmd(openSettingsNavigationServices);

        _mainPageVmdNavigationStore.CurrentValueChanged += () => OnPropertyChanged(nameof(EntityPageCurrentVmd));
        
        _additionalVmdNavigationStore.CurrentValueChanged += () => OnPropertyChanged(nameof(AdditionalCurrenVmd));

        loggerMessageBus.Bus += (logMes => LoggingInfo = logMes);
    }


    public ICommand OpenSettingsCommand { get; set; }

    public IEntityVmd? EntityPageCurrentVmd => _mainPageVmdNavigationStore.CurrentValue;

    public IAdditionalVmd? AdditionalCurrenVmd => _additionalVmdNavigationStore.CurrentValue;

    public BaseVmd? MainMenuCurrentVmd => _mainMenuVmdNavigationStore.CurrentValue;


    private string _loggingInfo;
    public string LoggingInfo
    {
        get => _loggingInfo;
        set => Set(ref _loggingInfo,value);
    }


 

}

