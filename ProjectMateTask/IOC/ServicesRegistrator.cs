using System;
using Microsoft.Extensions.DependencyInjection;
using ProjectMateTask.Infrastructure.MessageBuses;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.CloseNavigationServcies;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.TypeNavigationServices;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores;

namespace ProjectMateTask.IOC;

internal static class ServicesRegistrator
{
    public static IServiceCollection ServicesRegistration(this IServiceCollection services) =>
        services
            .AddTransient(CreateSelectPageNavigationStore)
            .AddTransient(CreateCloseAdditionalPageNavigationServices)
            .AddTransient(CreateMainEntityStoreTypeNavigationService)
            .AddTransient(CreateCloseMainEntityVmdNavigationServices)
            .AddSingleton<LoggerMessageBus>();
 

    private static SubEntityTypeNavigationService CreateSelectPageNavigationStore(
        IServiceProvider serviceProvider) => 
        new (serviceProvider.GetRequiredService<SubEntityVmdNavigationStore>());

    private static MainEntityStoreTypeNavigationService CreateMainEntityStoreTypeNavigationService(
        IServiceProvider serviceProvider) =>
        new(serviceProvider.GetRequiredService<MainEntityVmdNavigationStore>());

    private static CloseAdditionalPageNavigationServices CreateCloseAdditionalPageNavigationServices(
        IServiceProvider serviceProvider) =>
        new(serviceProvider.GetRequiredService<AdditionalPageVmdNavigationStore>());

    private static CloseMainEntityVmdNavigationServices CreateCloseMainEntityVmdNavigationServices(
        IServiceProvider serviceProvider) =>
        new(serviceProvider.GetRequiredService<MainEntityVmdNavigationStore>());





}