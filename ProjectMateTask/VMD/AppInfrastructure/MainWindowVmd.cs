using ProjectMateTask.Infrastructure.MessageBuses;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores.Base;
using ProjectMateTask.VMD.Base;

namespace ProjectMateTask.VMD.AppInfrastructure;

internal sealed class MainWindowVmd:BaseVmd
{
    private readonly INavigationStore _mainPageNavigationStore;
    
    private readonly INavigationStore _mainMenuNavigationStore;

    public MainWindowVmd(INavigationStore mainPageNavigationStore, INavigationStore mainMenuNavigationStore)
    {
        _mainPageNavigationStore = mainPageNavigationStore;
        
        _mainMenuNavigationStore = mainMenuNavigationStore;

        _mainPageNavigationStore.CurrentVmdChanged += CurrentVmdPageCanges;

        LoggerMessageBus.Log += (logMes => LoggingInfo = logMes);
    }

    public BaseVmd? MainPageCurrentVmd => _mainPageNavigationStore.CurrentVmd;

    public BaseVmd? MainMenuCurrentVmd => _mainMenuNavigationStore.CurrentVmd;


    private string _loggingInfo;
    public string LoggingInfo
    {
        get => _loggingInfo;
        set => Set(ref _loggingInfo,value);
    }

    private void CurrentVmdPageCanges()
    {
        OnPropertyChanged(nameof(MainPageCurrentVmd));
    }
}