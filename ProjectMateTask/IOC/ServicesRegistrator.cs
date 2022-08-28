using System;
using Microsoft.Extensions.DependencyInjection;
using ProjectMateTask.Infrastructure.MessageBuses;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.NavigationServices;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.CloseNavigationServcies;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.NavigationServices;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.TypeNavigationServices;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores;
using ProjectMateTask.VMD.Pages.AdditionalPagesVmds;

namespace ProjectMateTask.IOC;

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