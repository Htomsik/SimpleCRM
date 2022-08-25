using Microsoft.Extensions.DependencyInjection;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores;

namespace ProjectMateTask.IOC;

internal static class StoreRegistrator
{
    public static IServiceCollection StoreRegistration(this IServiceCollection services) =>
        services.AddSingleton<MainEntityNavigationStore>()
            .AddSingleton<MainMenuNavigationStore>()
            .AddSingleton<SubEntityNavigationStore>()
            .AddSingleton<AdditionalPageNavigationStore>();


}