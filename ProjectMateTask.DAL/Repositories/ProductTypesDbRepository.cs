using Microsoft.EntityFrameworkCore;
using ProjectMateTask.DAL.Context;
using ProjectMateTask.DAL.Entities.Types;

namespace ProjectMateTask.DAL.Repositories;

internal sealed class ProductTypesDbRepository : DbRepository<ProductType>
{
    public ProductTypesDbRepository(ProjectMateTaskDb db) : base(db)
    {
    }

    public override IQueryable<ProductType> TrackingItems => base.TrackingItems.AsNoTrackingWithIdentityResolution()
        .Include(item => item.Products);

   
}