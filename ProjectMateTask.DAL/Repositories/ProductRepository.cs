using Microsoft.EntityFrameworkCore;
using ProjectMateTask.DAL.Context;
using ProjectMateTask.DAL.Entities.Actors;
using ProjectMateTask.DAL.Repositories.Base;

namespace ProjectMateTask.DAL.Repositories;

internal sealed class ProductRepository : DbRepository<Product>
{
    public ProductRepository(ProjectMateTaskDb db) : base(db)
    {
    }

    public override IQueryable<Product> Items => base.Items
        .Include(item => item.Clients)
        .ThenInclude(item => item.Products)
        .Include(item => item.Clients)
        .ThenInclude(item => item.Status)
        .Include(item => item.Type);
}