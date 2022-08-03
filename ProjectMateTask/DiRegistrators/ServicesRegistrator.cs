using System;
using Microsoft.Extensions.DependencyInjection;
using ProjectMateTask.DAL.Entities.Actors;
using ProjectMateTask.DAL.Entities.Types;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores;
using ProjectMateTask.VMD.Base;
using ProjectMateTask.VMD.Pages;

namespace ProjectMateTask.DiRegistrators;

internal static class ServicesRegistrator
{
    public static IServiceCollection ServicesRegistration(this IServiceCollection services)
    {
        
        return services;
    }
    
}