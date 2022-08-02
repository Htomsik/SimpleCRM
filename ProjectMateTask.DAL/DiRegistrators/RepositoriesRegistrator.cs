using Microsoft.Extensions.DependencyInjection;
using ProjectMateTask.DAL.Entities.Actors;
using ProjectMateTask.DAL.Entities.Types;
using ProjectMateTask.DAL.Repositories;

namespace ProjectMateTask.DAL.DiRegistrators;

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