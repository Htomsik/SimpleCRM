﻿using Microsoft.Extensions.DependencyInjection;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores;

namespace ProjectMateTask.IOC;

internal static class StoreRegistrator
{
    public static IServiceCollection StoreRegistration(this IServiceCollection services) =>
        services.AddSingleton<MainBaseEntityVmdNavigationStore>()
            .AddSingleton<MainMenuVmdNavigationStore>()
            .AddSingleton<SubEntityVmdNavigationStore>()
            .AddSingleton<AdditionalPageVmdNavigationStore>();


}