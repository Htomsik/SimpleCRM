using System;
using Microsoft.Extensions.DependencyInjection;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.CloseNavigationServices;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.NavigationServices;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores;
using ProjectMateTask.VMD.AppInfrastructure;
using ProjectMateTask.VMD.Pages;
using ProjectMateTask.VMD.Pages.AdditionalPages;
using ProjectMateTask.VMD.Pages.EntityVmds;
using ProjectMateTask.VMD.Pages.SelectEntityVmds;

namespace ProjectMateTask.IOC;

internal static class VmdRegistrator
{
    public static IServiceCollection VmdRegistration(this IServiceCollection services)
    {
        services.AddSingleton(CreateMainWindowVmd);

        services.AddTransient(CreateMainMenuVmd);

        services.AddTransient<MainPageVmd>();

        #region EditEntity Vmds

        services.AddTransient<ManagersVmd>();

        services.AddTransient<ClientsVmd>();

        services.AddTransient<ProductVmd>();

        services.AddTransient<ClientStatusesVmd>();

        services.AddTransient<ProductTypeVmd>();

        #endregion

        #region SelectEntity Vmds

        services.AddTransient<ClientSelectVmd>();

        services.AddTransient<ManagerSelectVmd>();

        services.AddTransient<ProductSelectVmd>();

        services.AddTransient<ProductTypeSelectVmd>();

        services.AddTransient<ClientStatusSelectVmd>();

        #endregion


        #region Additional Vmds

        services.AddTransient<SettingsAdditionalPageVmd>();

        #endregion
        
        services.AddTransient(CreateMainPageNavigationServices);


        return services;
    }


    #region MainEntityPageVmdsNavigationServices

    private static INavigationService CreateMainPageNavigationServices(IServiceProvider serviceProvider)
    {
        return new MainEntityPageNavigationService(serviceProvider.GetRequiredService<MainEntityNavigationStore>(),
            serviceProvider.GetRequiredService<MainPageVmd>);
    }

    private static INavigationService CreateManagersPageNavigationServices(IServiceProvider serviceProvider)
    {
        return new MainEntityPageNavigationService(serviceProvider.GetRequiredService<MainEntityNavigationStore>(),
            serviceProvider.GetRequiredService<ManagersVmd>);
    }

    private static INavigationService CreateClientsPageNavigationServices(IServiceProvider serviceProvider)
    {
        return new MainEntityPageNavigationService(serviceProvider.GetRequiredService<MainEntityNavigationStore>(),
            serviceProvider.GetRequiredService<ClientsVmd>);
    }

    private static INavigationService CreateProductsPageNavigationServices(IServiceProvider serviceProvider)
    {
        return new MainEntityPageNavigationService(serviceProvider.GetRequiredService<MainEntityNavigationStore>(),
            serviceProvider.GetRequiredService<ProductVmd>);
    }

    private static INavigationService CreateClientStatusesPageNavigationServices(IServiceProvider serviceProvider)
    {
        return new MainEntityPageNavigationService(serviceProvider.GetRequiredService<MainEntityNavigationStore>(),
            serviceProvider.GetRequiredService<ClientStatusesVmd>);
    }

    private static INavigationService CreateProductTypesPageNavigationServices(IServiceProvider serviceProvider)
    {
        return new MainEntityPageNavigationService(serviceProvider.GetRequiredService<MainEntityNavigationStore>(),
            serviceProvider.GetRequiredService<ProductTypeVmd>);
    }

    #endregion

    #region AdditionalPdgeVmdsNavigationServices

    private static INavigationService CreateSettingsAdditionalPageNavigationServices(IServiceProvider serviceProvider)
    {
        return new AdditionalPageNavigationService(serviceProvider.GetRequiredService<AdditionalPageNavigationStore>(),
            serviceProvider.GetRequiredService<SettingsAdditionalPageVmd>);
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
            s.GetRequiredService<MainEntityNavigationStore>(),
            s.GetRequiredService<MainMenuNavigationStore>(),
            s.GetRequiredService<AdditionalPageNavigationStore>(),CreateSettingsAdditionalPageNavigationServices(s));
    }

    
    #endregion
}