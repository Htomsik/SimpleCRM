using Microsoft.EntityFrameworkCore;
using ProjectMateTask.DAL.Context;
using ProjectMateTask.DAL.Entities.Types;
using ProjectMateTask.DAL.Repositories.Base;

namespace ProjectMateTask.DAL.Repositories;

internal sealed class ProductTypesRepository : DbRepository<ProductType>
{
    public ProductTypesRepository(ProjectMateTaskDb db) : base(db)
    {
    }

    public override IQueryable<ProductType> Items => base.Items
        .Include(item => item.Products);
}