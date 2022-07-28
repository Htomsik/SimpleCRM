using Microsoft.EntityFrameworkCore;
using ProjectMateTask.DAL.Entities;
using ProjectMateTask.DAL.Entities.Types;

namespace ProjectMateTask.DAL.Context;

public class ProjectMateTaskDb:DbContext
{
    public DbSet<Client> Clients { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<Manager> Managers { get; set; }

    public DbSet<ClientStatus> ClientStatus { get; set; }
    public DbSet<ProductType> ProductTypes { get; set; }

    public ProjectMateTaskDb(DbContextOptions<ProjectMateTaskDb> options) : base(options)
    { }
}