using System;
using Microsoft.Extensions.DependencyInjection;
using ProjectMateTask.Infrastructure.MessageBuses;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.NavigationServices;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores;
using ProjectMateTask.VMD.AppInfrastructure;
using ProjectMateTask.VMD.Pages;
using ProjectMateTask.VMD.Pages.AdditionalPagesVmds;
using ProjectMateTask.VMD.Pages.Entities.MainEntityVmds;
using ProjectMateTask.VMD.Pages.Entities.SelectEntityVmds;
using ProjectMateTask.VMD.Pages.SettingsVmds;

namespace ProjectMateTask.IOC;

internal static class VmdRegistrator
{
    public static IServiceCollection VmdRegistration(this IServiceCollection services)
    {
        services.AddSingleton(CreateMainWindowVmd);

        services.AddTransient(CreateMainMenuVmd);

        services.AddTransient<MainPageVmd>();

        #region EditEntity Vmds

        services.AddTransient<MainManagerVmd>();

        services.AddTransient<MainClientVmd>();

        services.AddTransient<MainProductVmd>();

        services.AddTransient<MainClientStatusVmd>();

        services.AddTransient<MainProductTypeVmd>();

        #endregion

        #region SelectEntity Vmds

        services.AddTransient<ClientSubVmd>();

        services.AddTransient<SubManagerVmd>();

        services.AddTransient<SubProductVmd>();

        services.AddTransient<SubProductTypeVmd>();

        services.AddTransient<SubClientStatusVmd>();

        #endregion

        #region Additional Vmds

        services.AddTransient<SettingsAdditionalPageVmd>();

        #endregion

        #region Settings Vmds

        services.AddTransient<AboutProgramVmd>();

        #endregion
        
        
        return services;
    }

    
    #region AdditionalPdgeVmdsNavigationServices

    private static INavigationService CreateSettingsAdditionalPageNavigationServices(IServiceProvider serviceProvider)
    {
        return new AdditionalPageStoreNavigationService(serviceProvider.GetRequiredService<AdditionalPageVmdNavigationStore>(),
            serviceProvider.GetRequiredService<SettingsAdditionalPageVmd>);
    }
        
  

    #endregion

    #region Vmds
    

    private static MainWindowVmd CreateMainWindowVmd(IServiceProvider s)
    {
        return new MainWindowVmd(
            s.GetRequiredService<MainBaseEntityVmdNavigationStore>(),
            s.GetRequiredService<MainMenuVmdNavigationStore>(),
            s.GetRequiredService<AdditionalPageVmdNavigationStore>(),CreateSettingsAdditionalPageNavigationServices(s),s.GetRequiredService<LoggerMessageBus>());
    }

    private static MainMenuVmd CreateMainMenuVmd(IServiceProvider s) => new MainMenuVmd(s.GetRequiredService<MainEntityStoreTypeNavigationService>());


    #endregion
}