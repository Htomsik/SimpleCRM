using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjectMateTask.DAL.DiRegistrators;
using ProjectMateTask.Data;
using ProjectMateTask.IOC;
using ProjectMateTask.VMD.AppInfrastructure;
using ProjectMateTask.VW.Windows;

namespace ProjectMateTask
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static IHost _host;

        public static IHost Host
            => _host ??= Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();
        
        public static IServiceProvider Services => Host.Services;
        
        protected override async void OnStartup(StartupEventArgs e)
        {
            var host = Host;

            //Инициализция бд
            using (var scope = host.Services.CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<IDbInitializer>().InitializeAsync().Wait();
            }
            
            MainWindow = host.Services.GetRequiredService<MainWindow>();

            MainWindow.Show();
            
            base.OnStartup(e);

            await host.StartAsync();
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            var host = Host;

            base.OnExit(e);

            await host.StopAsync();

            host.Dispose();
            
        }
        
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

        
    }
}