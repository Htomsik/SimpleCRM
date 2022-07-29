using Microsoft.Extensions.DependencyInjection;
using ProjectMateTask.DAL.Entities;
using ProjectMateTask.DAL.Entities.Actors;
using ProjectMateTask.DAL.Entities.Types;
using ProjectMateTask.DAL.Repositories;
using ProjectMateTask.DAL.Repositories.Base;

namespace ProjectMateTask.DAL.DiRegistrators;

public static class RepositoriesRegistrator
{
    public static IServiceCollection RepositoriesRegistration(this IServiceCollection services)
    {
        services.AddTransient<IRepository<Client>, ClientRepository>();
        services.AddTransient<IRepository<Manager>, ManagerRepository>();
        services.AddTransient<IRepository<Product>, ProductRepository>();
        services.AddTransient<IRepository<ProductType>, ProductTypesRepository>();
        services.AddTransient<IRepository<ClientStatus>, ClientStatusRepository>();
        return services;
    }
}