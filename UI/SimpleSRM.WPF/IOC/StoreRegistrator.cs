using Microsoft.Extensions.DependencyInjection;
using SimpleSRM.WPF.Stores.AppInfrastructure.NavigationStores;

namespace SimpleSRM.WPF.IOC;

/// <summary>
///     Регистратор хранилищ в IOC контейнере
/// </summary>
internal static class StoreRegistrator
{
    public static IServiceCollection StoreRegistration(this IServiceCollection services) =>
        services.AddSingleton<MainEntityVmdNavigationStore>()
            .AddSingleton<MainMenuVmdNavigationStore>()
            .AddSingleton<SubEntityVmdNavigationStore>()
            .AddSingleton<AdditionalPageVmdNavigationStore>();


}