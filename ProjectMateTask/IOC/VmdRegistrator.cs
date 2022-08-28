using System;
using Microsoft.Extensions.DependencyInjection;
using ProjectMateTask.Infrastructure.MessageBuses;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.NavigationServices;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.CloseNavigationServcies;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.NavigationServices;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.TypeNavigationServices;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores;
using ProjectMateTask.VMD.AppInfrastructure;
using ProjectMateTask.VMD.Pages;
using ProjectMateTask.VMD.Pages.AdditionalPagesVmds;
using ProjectMateTask.VMD.Pages.Entities.MainEntityVmds;
using ProjectMateTask.VMD.Pages.Entities.SelectEntityVmds;
using ProjectMateTask.VMD.Pages.SettingsVmds;

namespace ProjectMateTask.IOC;

/// <summary>
///     Регистратор Vmd типов в IOC контейнере
/// </summary>
internal static class VmdRegistrator
{
    public static IServiceCollection VmdRegistration(this IServiceCollection services)
    {
        services.AddSingleton(CreateMainWindowVmd);

        services.AddTransient(CreateMainMenuVmd);

        services.AddTransient<HomeVmd>();

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

    
    #region Vmds
    
    private static MainWindowVmd CreateMainWindowVmd(IServiceProvider s)
    {
        return new MainWindowVmd(
            s.GetRequiredService<MainEntityVmdNavigationStore>(),
            s.GetRequiredService<CloseMainEntityVmdNavigationServices>(),
            s.GetRequiredService<MainMenuVmdNavigationStore>(),
            s.GetRequiredService<AdditionalPageVmdNavigationStore>(),
           s.GetRequiredService<AdditionalPageStoreNavigationService>(),
            s.GetRequiredService<LoggerMessageBus>());
    }

    private static MainMenuVmd CreateMainMenuVmd(IServiceProvider s) => new (s.GetRequiredService<MainEntityStoreTypeNavigationService>());

    #endregion
}