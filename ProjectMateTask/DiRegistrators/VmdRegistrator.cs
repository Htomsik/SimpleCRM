using System;
using Microsoft.Extensions.DependencyInjection;
using ProjectMateTask.DAL.Entities.Actors;
using ProjectMateTask.DAL.Entities.Types;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores;
using ProjectMateTask.VMD;
using ProjectMateTask.VMD.AppInfrastructure;
using ProjectMateTask.VMD.Base;
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
            CreateProductsPageNavigationServices(s),
            CreateMainPageNavigationServices(s),
            CreateClientStatusesPageNavigationServices(s)));

        services.AddTransient<MainPageVmd>();
        
        services.AddTransient<BaseNotGenericEntityVmdEntityPageVmd<Manager>,ManagersVmdEntityPageVmd>();
        
        services.AddTransient<BaseNotGenericEntityVmdEntityPageVmd<Client>,ClientsVmdEntityPageVmd>();
        
        services.AddTransient<BaseNotGenericEntityVmdEntityPageVmd<Product>,ProductVmdEntityPageVmd>();
        
        services.AddTransient<BaseNotGenericEntityVmdEntityPageVmd<ClientStatus>,ClientStatusesVmdEntityPageVmd>();

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
            serviceProvider.GetRequiredService<BaseNotGenericEntityVmdEntityPageVmd<Manager>>);
    }
    
    private static INavigationService CreateClientsPageNavigationServices(IServiceProvider serviceProvider)
    {
        return new MainPageNavigationServices(serviceProvider.GetRequiredService<MainPageNavigationStore>(),
            serviceProvider.GetRequiredService<BaseNotGenericEntityVmdEntityPageVmd<Client>>);
    }
    
    private static INavigationService CreateProductsPageNavigationServices(IServiceProvider serviceProvider)
    {
        return new MainPageNavigationServices(serviceProvider.GetRequiredService<MainPageNavigationStore>(),
            serviceProvider.GetRequiredService<BaseNotGenericEntityVmdEntityPageVmd<Product>>);
    }
    
    
    private static INavigationService CreateClientStatusesPageNavigationServices(IServiceProvider serviceProvider)
    {
        return new MainPageNavigationServices(serviceProvider.GetRequiredService<MainPageNavigationStore>(),
            serviceProvider.GetRequiredService<BaseNotGenericEntityVmdEntityPageVmd<ClientStatus>>);
    }
}

    #endregion
   