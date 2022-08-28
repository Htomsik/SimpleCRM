using Microsoft.EntityFrameworkCore;
using ProjectMateTask.DAL.Entities.Actors;
using ProjectMateTask.DAL.Entities.Types;

namespace ProjectMateTask.DAL.Context;

/// <summary>
///     Контекст взаимодействия с базой данных
/// </summary>
public class ProjectMateTaskDb : DbContext
{
    public ProjectMateTaskDb(DbContextOptions<ProjectMateTaskDb> options) : base(options)
    {
    }

    /// <summary>
    ///     Список клиентов в бд
    /// </summary>
    public DbSet<Client> Clients { get; set; }

    /// <summary>
    ///     Список подуктов в бд
    /// </summary>
    public DbSet<Product> Products { get; set; }

    /// <summary>
    ///     Список менеджеров в бд
    /// </summary>
    public DbSet<Manager> Managers { get; set; }

    /// <summary>
    ///     Список статусов клиентов в бд
    /// </summary>
    public DbSet<ClientStatus> ClientStatus { get; set; }

    /// <summary>
    ///     Список типов клиентов в бд
    /// </summary>
    public DbSet<ProductType> ProductTypes { get; set; }
}