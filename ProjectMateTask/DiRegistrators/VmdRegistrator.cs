using System;
using Microsoft.Extensions.DependencyInjection;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores;
using ProjectMateTask.VMD;

namespace ProjectMateTask.DiRegistrators;

internal static class VmdRegistrator
{
    public static IServiceCollection VmdRegistration(this IServiceCollection services)
    {
        
        services.AddSingleton(s => new MainWindowVmd(
            s.GetRequiredService<MainPageNavigationStore>(),s.GetRequiredService<MainMenuNavigationStore>()));

        services.AddSingleton(s=> new MainMenuVmd(CreateMainPageNavigationServices(s),CreateMainPageNavigationServices(s)));

        services.AddTransient<MainPageVmd>();

        services.AddSingleton<INavigationService>(CreateMainPageNavigationServices);
        
        return services;
    }
    
    
    private static INavigationService CreateMainPageNavigationServices(IServiceProvider serviceProvider)
    {
        return new MainPageNavigationServices(serviceProvider.GetRequiredService<MainPageNavigationStore>(),
            serviceProvider.GetRequiredService<MainPageVmd>);
    }
}