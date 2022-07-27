using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace ProjectMateTask;

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
            .ConfigureAppConfiguration((host, cfg) => cfg
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json", true, true)
            );
        
        return hostBuilder;
    }
}