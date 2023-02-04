using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using SimpleSRM.WPF.Infrastructure.Logging;

namespace SimpleSRM.WPF;

public class Program
{
    [STAThread]
    public static void Main()
    {
        var app = new App();

        app.InitializeComponent();

        app.Run();
        
    }
    
    public static IHostBuilder CreateHostBuilder(string[] Args)
    {
        var hostBuilder = Host.CreateDefaultBuilder(Args)
            .UseContentRoot(Environment.CurrentDirectory)
            .ConfigureServices(App.ConfigureServices)
            .UseSerilog((host, loggerConfiguration) =>
            {
                loggerConfiguration
                    .WriteTo.File("Log-.txt", rollingInterval: RollingInterval.Day)
                    .WriteTo.Sink(new MessageBusLogSink())
                    .MinimumLevel.Information()
                    .MinimumLevel.Override(nameof(Microsoft),LogEventLevel.Error)
                    ;

            })
            .ConfigureAppConfiguration((host, cfg) => cfg
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json", true, true)
            );
        
        return hostBuilder;
    }
}