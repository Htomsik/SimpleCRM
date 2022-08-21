using System.Windows.Input;
using ProjectMateTask.Infrastructure.CMD.AppInfrastructure;
using ProjectMateTask.Infrastructure.MessageBuses;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.NavigationServices;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores.Base;
using ProjectMateTask.VMD.Base;
using ProjectMateTask.VMD.Pages.AdditionalPages.Base;
using ProjectMateTask.VMD.Pages.EntityPages;

namespace ProjectMateTask.VMD.AppInfrastructure;

internal sealed class MainWindowVmd:BaseVmd
{
    private readonly INavigationStore<BaseNotGenericEntityVmd> _mainEntityPageNavigationStore;
    
    private readonly INavigationStore<BaseVmd> _mainMenuNavigationStore;
    
    private readonly INavigationStore<BaseAdditionalVmd> _additionalNavigationStore;

    public MainWindowVmd(INavigationStore<BaseNotGenericEntityVmd> MainEntityPageNavigationStore,
        INavigationStore<BaseVmd> mainMenuNavigationStore,
        INavigationStore<BaseAdditionalVmd> additionalNavigationStore,
        INavigationService openSettingsNavigationServices)
    {
        _mainEntityPageNavigationStore = MainEntityPageNavigationStore;
        
        _mainMenuNavigationStore = mainMenuNavigationStore;
        
        _additionalNavigationStore = additionalNavigationStore;

        OpenSettingsCommand = new NavigationCmd(openSettingsNavigationServices, ()=> true);

        _mainEntityPageNavigationStore.CurrentVmdChanged += () => OnPropertyChanged(nameof(EntityPageCurrentVmd));
        
        _additionalNavigationStore.CurrentVmdChanged += () => OnPropertyChanged(nameof(AdditionalCurrenVmd));

        LoggerMessageBus.Log += (logMes => LoggingInfo = logMes);
    }


    public ICommand OpenSettingsCommand { get; set; }

    public BaseNotGenericEntityVmd? EntityPageCurrentVmd => _mainEntityPageNavigationStore.CurrentVmd;

    public BaseAdditionalVmd? AdditionalCurrenVmd => _additionalNavigationStore.CurrentVmd;

    public BaseVmd? MainMenuCurrentVmd => _mainMenuNavigationStore.CurrentVmd;


    private string _loggingInfo;
    public string LoggingInfo
    {
        get => _loggingInfo;
        set => Set(ref _loggingInfo,value);
    }


 

}

