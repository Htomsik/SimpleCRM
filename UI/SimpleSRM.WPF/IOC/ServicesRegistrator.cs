using System;
using Microsoft.Extensions.DependencyInjection;
using SimpleSRM.WPF.Infrastructure.MessageBuses;
using SimpleSRM.WPF.Services.AppInfrastructure.NavigationServices.CloseNavigationServcies;
using SimpleSRM.WPF.Services.AppInfrastructure.NavigationServices.NavigationServices;
using SimpleSRM.WPF.Services.AppInfrastructure.NavigationServices.TypeNavigationServices;
using SimpleSRM.WPF.Services.AppInfrastructure.UserDialogServices;
using SimpleSRM.WPF.Services.AppInfrastructure.UserDialogServices.Base;
using SimpleSRM.WPF.Stores.AppInfrastructure.NavigationStores;
using SimpleSRM.WPF.VMD.Pages.AdditionalPagesVmds;

namespace SimpleSRM.WPF.IOC;

/// <summary>
///     Регистратор сервисов в IOC контейнере
/// </summary>
internal static class ServicesRegistrator
{
    public static IServiceCollection ServicesRegistration(this IServiceCollection services) =>
        services
            .AddTransient(CreateSelectPageNavigationStore)
            .AddTransient(CreateCloseAdditionalPageNavigationServices)
            .AddTransient(CreateMainEntityStoreTypeNavigationService)
            .AddTransient(CreateCloseMainEntityVmdNavigationServices)
            .AddTransient(CreateSettingsAdditionalPageNavigationServices)
            .AddTransient<IUserDialogService,MessageBoxUserDialogService>()
            .AddSingleton<LoggerMessageBus>();
    
    #region Navigation services

    #region SubEntityTypeNavigationService

    private static SubEntityTypeNavigationService CreateSelectPageNavigationStore(
        IServiceProvider serviceProvider) => 
        new (serviceProvider.GetRequiredService<SubEntityVmdNavigationStore>());

    #endregion

    #region AdditionalPageStoreNavigationService

    private static AdditionalPageStoreNavigationService CreateSettingsAdditionalPageNavigationServices(IServiceProvider serviceProvider)
    {
        return new AdditionalPageStoreNavigationService(serviceProvider.GetRequiredService<AdditionalPageVmdNavigationStore>(),
            serviceProvider.GetRequiredService<SettingsAdditionalPageVmd>);
    }
    
    private static CloseAdditionalPageNavigationServices CreateCloseAdditionalPageNavigationServices(
        IServiceProvider serviceProvider) =>
        new(serviceProvider.GetRequiredService<AdditionalPageVmdNavigationStore>());

    #endregion

    #region MainEntityStoreTypeNavigationService

    private static MainEntityStoreTypeNavigationService CreateMainEntityStoreTypeNavigationService(
        IServiceProvider serviceProvider) =>
        new(serviceProvider.GetRequiredService<MainEntityVmdNavigationStore>());
    
    private static CloseMainEntityVmdNavigationServices CreateCloseMainEntityVmdNavigationServices(
        IServiceProvider serviceProvider) =>
        new(serviceProvider.GetRequiredService<MainEntityVmdNavigationStore>());

    #endregion

    #endregion




}