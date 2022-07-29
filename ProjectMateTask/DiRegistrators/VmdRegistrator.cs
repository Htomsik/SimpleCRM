using System;
using Microsoft.Extensions.DependencyInjection;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores;
using ProjectMateTask.VMD;
using ProjectMateTask.VMD.AppInfrastructure;
using ProjectMateTask.VMD.Pages;
using ProjectMateTask.VMD.Pages.EntityPages;

namespace ProjectMateTask.DiRegistrators;

internal  static class VmdRegistrator
{
    public static IServiceCollection VmdRegistration(this IServiceCollection services)
    {
        
        services.AddSingleton(s => new MainWindowVmd(
            s.GetRequiredService<MainPageNavigationStore>(),s.GetRequiredService<MainMenuNavigationStore>()));

        services.AddSingleton(s=> new MainMenuVmd(CreateManagersPageNavigationServices(s),
            CreateClientsPageNavigationServices(s),
            CreateProductsPageNavigationServices(s),CreateMainPageNavigationServices(s)));

        services.AddTransient<MainPageVmd>();
        
        services.AddTransient<ManagersPageVmd>();
        
        services.AddTransient<ClientsPageVmd>();
        
        services.AddTransient<ProductPageVmd>();

        services.AddSingleton<INavigationService>(CreateMainPageNavigationServices);
        
        return services;
    }


    #region MainPageVmdsNavigationServices

    private static INavigationService CreateMainPageNavigationServices(IServiceProvider serviceProvider)
    {
        return new MainPageNavigationServices(serviceProvider.GetRequiredService<MainPageNavigationStore>(),
            serviceProvider.GetRequiredService<MainPageVmd>);
    }
    
    private static INavigationService CreateManagersPageNavigationServices(IServiceProvider serviceProvider)
    {
        return new MainPageNavigationServices(serviceProvider.GetRequiredService<MainPageNavigationStore>(),
            serviceProvider.GetRequiredService<ManagersPageVmd>);
    }
    
    private static INavigationService CreateClientsPageNavigationServices(IServiceProvider serviceProvider)
    {
        return new MainPageNavigationServices(serviceProvider.GetRequiredService<MainPageNavigationStore>(),
            serviceProvider.GetRequiredService<ClientsPageVmd>);
    }
    
    private static INavigationService CreateProductsPageNavigationServices(IServiceProvider serviceProvider)
    {
        return new MainPageNavigationServices(serviceProvider.GetRequiredService<MainPageNavigationStore>(),
            serviceProvider.GetRequiredService<ProductPageVmd>);
    }
    
}

    #endregion
   