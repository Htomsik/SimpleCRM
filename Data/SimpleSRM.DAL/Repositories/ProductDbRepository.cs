using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimpleSRM.DAL.Context;
using SimpleSRM.DAL.Repositories.Base;
using SimpleSRM.Models.Entities.Actors;

namespace SimpleSRM.DAL.Repositories;

internal sealed class ProductDbRepository : DbRepository<Product>
{
  
    public override IQueryable<Product> FullTrackingItems => base.FullTrackingItems
        .Include(item => item.Clients)
        .ThenInclude(item => item.Products)
        .Include(item => item.Clients)
        .ThenInclude(item => item.Status)
        .Include(item => item.Type);


    public ProductDbRepository(DataDb db, ILogger<DbRepository<Product>> logger) : base(db, logger)
    {
    }
}