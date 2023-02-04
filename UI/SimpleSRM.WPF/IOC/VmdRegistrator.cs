using System;
using Microsoft.Extensions.DependencyInjection;
using SimpleSRM.WPF.Infrastructure.MessageBuses;
using SimpleSRM.WPF.Services.AppInfrastructure.NavigationServices.CloseNavigationServcies;
using SimpleSRM.WPF.Services.AppInfrastructure.NavigationServices.NavigationServices;
using SimpleSRM.WPF.Services.AppInfrastructure.NavigationServices.TypeNavigationServices;
using SimpleSRM.WPF.Stores.AppInfrastructure.NavigationStores;
using SimpleSRM.WPF.VMD.AppInfrastructure;
using SimpleSRM.WPF.VMD.AppInfrastructure.MenuVMds;
using SimpleSRM.WPF.VMD.Pages;
using SimpleSRM.WPF.VMD.Pages.AdditionalPagesVmds;
using SimpleSRM.WPF.VMD.Pages.Entities.MainEntityVmds;
using SimpleSRM.WPF.VMD.Pages.Entities.SelectEntityVmds;
using SimpleSRM.WPF.VMD.Pages.SettingsVmds;

namespace SimpleSRM.WPF.IOC;

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