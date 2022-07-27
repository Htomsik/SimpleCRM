using Microsoft.Extensions.DependencyInjection;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores;

namespace ProjectMateTask.DiRegistrators;

internal static class StoreRegistrator
{
    public static IServiceCollection StoreRegistration(this IServiceCollection services)
    {

        services.AddSingleton<MainPageNavigationStore>();
        
        return services;
    }
}
