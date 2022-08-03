using Microsoft.EntityFrameworkCore;
using ProjectMateTask.DAL.Context;
using ProjectMateTask.DAL.Entities.Actors;

namespace ProjectMateTask.DAL.Repositories;

internal sealed class ProductDbRepository : DbRepository<Product>
{
    public ProductDbRepository(ProjectMateTaskDb db) : base(db)
    {
    }
    
    public override IQueryable<Product> TrackingItems => base.TrackingItems
        .Include(item => item.Clients)
        .ThenInclude(item => item.Products)
        .Include(item => item.Clients)
        .ThenInclude(item => item.Status)
        .Include(item => item.Type);

    
}