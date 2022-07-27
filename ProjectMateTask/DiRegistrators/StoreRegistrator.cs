using Microsoft.Extensions.DependencyInjection;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores;

namespace ProjectMateTask.DiRegistrators;

internal static class StoreRegistrator
{
    public static IServiceCollection StoreRegistration(this IServiceCollection services)
    {

        #region Navigation stores

        services.AddSingleton<MainPageNavigationStore>();
        
        services.AddSingleton<MainMenuNavigationStore>();

        #endregion
      
        
        return services;
    }
}
