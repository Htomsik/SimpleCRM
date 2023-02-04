using System;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SimpleSRM.DAL.DiRegistrators;
using SimpleSRM.WPF.Data;
using SimpleSRM.WPF.IOC;
using SimpleSRM.WPF.Services.AppInfrastructure.UserDialogServices.Base;
using SimpleSRM.WPF.VMD.AppInfrastructure;
using SimpleSRM.WPF.VW.Windows;

namespace SimpleSRM.WPF;

/// <summary>
///     Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static IServiceProvider Services => Host.Services;

    #region Отловка необработанных исключений

    
    private void SetupExceptionHandling()
    {
        AppDomain.CurrentDomain.UnhandledException += (s, e) =>
            LogUnhandledException((Exception)e.ExceptionObject, "AppDomain.CurrentDomain.UnhandledException");

        DispatcherUnhandledException += (s, e) =>
        {
            LogUnhandledException(e.Exception, "Application.Current.DispatcherUnhandledException");
            e.Handled = true;
        };

        TaskScheduler.UnobservedTaskException += (s, e) =>
        {
            LogUnhandledException(e.Exception, "TaskScheduler.UnobservedTaskException");
            e.SetObserved();
        };
    }
    
    
    private void LogUnhandledException(Exception e, string source)
    {
        switch (e)
        {
            case NotSupportedException:
                Logger.LogError(e.Message);
                break;

            default:
                UserDialogService.ConfirmCriticalError(
                    $"Произошло необработанное исключение: {e.Message}. Подробности смотрите в Log файле",
                    "Необработанная ошибка");
                Logger.LogCritical($"Неизветная ошибка:{e.Message}");
                Current.Shutdown();
                break;
        }
    }
    
    #endregion

    /// <summary>
    ///     IOC контейнер
    /// </summary>
    internal static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
    {
        services.AddSingleton(s => new MainWindow
        {
            DataContext = s.GetRequiredService<MainWindowVmd>()
        });

        services
            .StoreRegistration()
            .ServicesRegistration()
            .VmdRegistration()
            .RepositoriesRegistration()
            .AddDatabase(host.Configuration.GetSection("Database"));
    }

    #region Host

    private static IHost? _host;

    public static IHost Host
        => _host ??= Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

    #endregion

    #region Logger : логирование для App класа

    private static ILogger? _logger;

    /// <summary>
    ///     Локальный логгер для фиксирования необработанных исключений
    /// </summary>
    private static ILogger Logger => _logger ??= Services.GetRequiredService<ILogger<App>>();

    #endregion

    #region UserDialogService : сервис модальных окон

    private static IUserDialogService? _userDialogService;

    /// <summary>
    ///     Сервис модальных окон
    /// </summary>
    public static IUserDialogService UserDialogService =>
        _userDialogService ??= Services.GetRequiredService<IUserDialogService>();

    #endregion
    
    #region OnStartup и OnExit

    protected override async void OnStartup(StartupEventArgs e)
    {
        var host = Host;
        
        base.OnStartup(e);

        await host.StartAsync();
        
        SetupExceptionHandling();
        
        //Инициализция бд
        using (var scope = host.Services.CreateScope())
        {
            await scope.ServiceProvider.GetRequiredService<IDbInitializer>().InitializeAsync();
        }

        MainWindow = host.Services.GetRequiredService<MainWindow>();

        MainWindow.Show();
        
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        var host = Host;

        base.OnExit(e);

        await host.StopAsync();

        host.Dispose();
    }

    #endregion
}