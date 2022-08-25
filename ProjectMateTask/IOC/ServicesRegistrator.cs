﻿using System;
using Microsoft.Extensions.DependencyInjection;
using ProjectMateTask.Infrastructure.MessageBuses;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores;

namespace ProjectMateTask.IOC;

internal static class ServicesRegistrator
{
    public static IServiceCollection ServicesRegistration(this IServiceCollection services) =>
        services.AddTransient(CreateSelectPageNavigationStore)
            .AddTransient(createCloseAdditionalPageNavigationServices)
            .AddSingleton<LoggerMessageBus>();
 

    private static SubEntityNavigationService CreateSelectPageNavigationStore(IServiceProvider serviceProvider) => 
        new (serviceProvider.GetRequiredService<SubEntityNavigationStore>());

    private static CloseAdditionalPageNavigationServices createCloseAdditionalPageNavigationServices(
        IServiceProvider serviceProvider) =>
        new(serviceProvider.GetRequiredService<AdditionalPageNavigationStore>());


}