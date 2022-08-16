using System;
using Microsoft.Extensions.DependencyInjection;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores;

namespace ProjectMateTask.IOC;

internal static class ServicesRegistrator
{
    public static IServiceCollection ServicesRegistration(this IServiceCollection services)
    {
        services.AddTransient(CreateSelectPageNavigationStore);

        return services;
    }

    private static SubEntityNavigationServices CreateSelectPageNavigationStore(IServiceProvider serviceProvider)
    {
        return new SubEntityNavigationServices(serviceProvider.GetRequiredService<EntityPageNavigationStore>());
    }
    
}