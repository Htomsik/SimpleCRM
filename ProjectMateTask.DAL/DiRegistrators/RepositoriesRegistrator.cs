using Microsoft.Extensions.DependencyInjection;
using ProjectMateTask.DAL.Repositories;
using ProjetMateTaskEntities.Entities.Actors;
using ProjetMateTaskEntities.Entities.Types;

namespace ProjectMateTask.DAL.DiRegistrators;

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