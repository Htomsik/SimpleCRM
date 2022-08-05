using System;
using Microsoft.Extensions.DependencyInjection;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores;

namespace ProjectMateTask.IOC;

internal static class ServicesRegistrator
{
    public static IServiceCollection ServicesRegistration(this IServiceCollection services)
    {
        services.AddTransient(CreateClientSelectPageNavigationStore);

        return services;
    }

    private static EntityPageNavigationServices CreateClientSelectPageNavigationStore(IServiceProvider serviceProvider)
    {
        return new EntityPageNavigationServices(serviceProvider.GetRequiredService<EntityPageNavigationStore>());
    }
}