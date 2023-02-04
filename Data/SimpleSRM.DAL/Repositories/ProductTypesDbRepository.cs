using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimpleSRM.DAL.Context;
using SimpleSRM.DAL.Repositories.Base;
using SimpleSRM.Models.Entities.Types;

namespace SimpleSRM.DAL.Repositories;

internal sealed class ProductTypesDbRepository : DbRepository<ProductType>
{
  

    public override IQueryable<ProductType> FullTrackingItems => base.FullTrackingItems
        .Include(item => item.Products);


    public ProductTypesDbRepository(DataDb db, ILogger<DbRepository<ProductType>> logger) : base(db, logger)
    {
    }
}