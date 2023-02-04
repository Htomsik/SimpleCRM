using Microsoft.Extensions.DependencyInjection;
using SimpleSRM.DAL.Repositories;
using SimpleSRM.DAL.Repositories.Base;
using SimpleSRM.Models.Entities.Actors;
using SimpleSRM.Models.Entities.Types;

namespace SimpleSRM.DAL.DiRegistrators;

/// <summary>
///     Регистратор репозиториев для Entity типов
/// </summary>
public static class RepositoriesRegistrator
{
    public static IServiceCollection RepositoriesRegistration(this IServiceCollection services)
    {
        services.AddTransient<IRepository<Client>, ClientDbRepository>();
        services.AddTransient<IRepository<Manager>, ManagerDbRepository>();
        services.AddTransient<IRepository<Product>, ProductDbRepository>();
        services.AddTransient<IRepository<ProductType>, ProductTypesDbRepository>();
        services.AddTransient<IRepository<ClientStatus>, ClientStatusDbRepository>();
        return services;
    }
}