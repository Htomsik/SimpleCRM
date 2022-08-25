using System;
using Microsoft.Extensions.DependencyInjection;
using ProjectMateTask.Infrastructure.MessageBuses;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores;

namespace ProjectMateTask.IOC;

internal static class ServicesRegistrator
{
    public static IServiceCollection ServicesRegistration(this IServiceCollection services) =>
        services
            .AddTransient(CreateSelectPageNavigationStore)
            .AddTransient(CreateCloseAdditionalPageNavigationServices)
            .AddTransient(CreateMainEntityStoreTypeNavigationService)
            .AddSingleton<LoggerMessageBus>();
 

    private static SubEntityTypeNavigationService CreateSelectPageNavigationStore(
        IServiceProvider serviceProvider) => 
        new (serviceProvider.GetRequiredService<SubEntityNavigationStore>());

    private static MainEntityStoreTypeNavigationService CreateMainEntityStoreTypeNavigationService(
        IServiceProvider serviceProvider) =>
        new(serviceProvider.GetRequiredService<MainEntityNavigationStore>());

    private static CloseAdditionalPageNavigationServices CreateCloseAdditionalPageNavigationServices(
        IServiceProvider serviceProvider) =>
        new(serviceProvider.GetRequiredService<AdditionalPageNavigationStore>());


}