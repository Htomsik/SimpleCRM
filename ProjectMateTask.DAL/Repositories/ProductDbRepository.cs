using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectMateTask.DAL.Context;
using ProjectMateTask.DAL.Entities.Actors;

namespace ProjectMateTask.DAL.Repositories;

internal sealed class ProductDbRepository : DbRepository<Product>
{
  
    public override IQueryable<Product> FullTrackingItems => base.FullTrackingItems
        .Include(item => item.Clients)
        .ThenInclude(item => item.Products)
        .Include(item => item.Clients)
        .ThenInclude(item => item.Status)
        .Include(item => item.Type);


    public ProductDbRepository(ProjectMateTaskDb db, ILogger<DbRepository<Product>> logger) : base(db, logger)
    {
    }
}