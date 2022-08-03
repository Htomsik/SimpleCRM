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
using ProjectMateTask.VMD.Pages.SelectEntityPages;

namespace ProjectMateTask.DiRegistrators;

internal  static class VmdRegistrator
{
    public static IServiceCollection VmdRegistration(this IServiceCollection services)
    {
        
        services.AddSingleton<MainWindowVmd>(CreateMainWindowVmd);

        services.AddTransient<MainMenuVmd>(CreateMainMenuVmd);

        services.AddTransient<MainPageVmd>();
        
        services.AddTransient<ManagersPageVmd>();
        
        services.AddTransient<ClientsPageVmd>();
        
        services.AddTransient<ProductPageVmd>();
        
        services.AddTransient<ClientStatusesPageVmd>();
        
        services.AddTransient<ProductTypePageVmd>();

        services.AddTransient<ClientSelectEntityPage>();
        
        
        
        services.AddTransient<INavigationService>(CreateMainPageNavigationServices);
        
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
            serviceProvider.GetRequiredService<BaseEntityPageVmd<Manager>>);
    }
    
    private static INavigationService CreateClientsPageNavigationServices(IServiceProvider serviceProvider)
    {
        return new MainPageNavigationServices(serviceProvider.GetRequiredService<MainPageNavigationStore>(),
            serviceProvider.GetRequiredService<BaseEntityPageVmd<Client>>);
    }
    
    private static INavigationService CreateProductsPageNavigationServices(IServiceProvider serviceProvider)
    {
        return new MainPageNavigationServices(serviceProvider.GetRequiredService<MainPageNavigationStore>(),
            serviceProvider.GetRequiredService<ProductPageVmd>);
    }
    
    private static INavigationService CreateClientStatusesPageNavigationServices(IServiceProvider serviceProvider)
    {
        return new MainPageNavigationServices(serviceProvider.GetRequiredService<MainPageNavigationStore>(),
            serviceProvider.GetRequiredService<ClientStatusesPageVmd>);
    }
    
    private static INavigationService CreateProductTypesPageNavigationServices(IServiceProvider serviceProvider)
    {
        return new MainPageNavigationServices(serviceProvider.GetRequiredService<MainPageNavigationStore>(),
            serviceProvider.GetRequiredService<ProductTypePageVmd>);
    }
    #endregion

    #region EntityPageVmdsNavifationServices

    private static INavigationService CreateClientSelectPageNavigationStore(IServiceProvider serviceProvider)
    {
        return new EntityPageNavigationServices(serviceProvider.GetRequiredService<EntityPageNavigationStore>(),
            serviceProvider.GetRequiredService<ClientSelectEntityPage>);
    }

    #endregion

    #region Vmds

    private static MainMenuVmd CreateMainMenuVmd(IServiceProvider s)
    {
        return new MainMenuVmd(CreateManagersPageNavigationServices(s),
            CreateClientsPageNavigationServices(s),
            CreateProductsPageNavigationServices(s),
            CreateMainPageNavigationServices(s),
            CreateClientStatusesPageNavigationServices(s),
            CreateProductTypesPageNavigationServices(s));
    }

    private static MainWindowVmd CreateMainWindowVmd(IServiceProvider s)
    {
        return new MainWindowVmd(
            s.GetRequiredService<MainPageNavigationStore>(),
            s.GetRequiredService<MainMenuNavigationStore>());
    }

    #endregion
}

   
   