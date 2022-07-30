using ProjectMateTask.DAL.Entities.Types;
using ProjectMateTask.DAL.Repositories;
using ProjectMateTask.VMD.Base;

namespace ProjectMateTask.VMD.Pages.EntityPages;

internal sealed class ProductTypePageVmd:BaseEntityPageVmd<ProductType>
{
    public ProductTypePageVmd(IRepository<ProductType> entitiesRepository) : base(entitiesRepository)
    {
    }
}