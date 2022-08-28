using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectMateTask.DAL.Context;
using ProjetMateTaskEntities.Entities.Types;

namespace ProjectMateTask.DAL.Repositories;

internal sealed class ProductTypesDbRepository : DbRepository<ProductType>
{
  

    public override IQueryable<ProductType> FullTrackingItems => base.FullTrackingItems
        .Include(item => item.Products);


    public ProductTypesDbRepository(ProjectMateTaskDb db, ILogger<DbRepository<ProductType>> logger) : base(db, logger)
    {
    }
}