using Microsoft.Extensions.DependencyInjection;
using ProjectMateTask.DAL.Entities;
using ProjectMateTask.DAL.Entities.Types;
using ProjectMateTask.DAL.Repositories;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores;
using ProjectMateTask.Stores.TemporaryStores;

namespace ProjectMateTask.DiRegistrators;

internal static class StoreRegistrator
{
    public static IServiceCollection StoreRegistration(this IServiceCollection services)
    {

        #region Navigation stores

        services.AddSingleton<MainPageNavigationStore>();
        
        services.AddSingleton<MainMenuNavigationStore>();

        services.AddSingleton<SubEntityReadOnlyCollectionStore>();

        #endregion
        
        return services;
    }
}
