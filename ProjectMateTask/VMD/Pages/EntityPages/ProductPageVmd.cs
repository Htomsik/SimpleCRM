using ProjectMateTask.DAL.Entities;
using ProjectMateTask.DAL.Entities.Actors;
using ProjectMateTask.DAL.Repositories;
using ProjectMateTask.VMD.Base;

namespace ProjectMateTask.VMD.Pages.EntityPages;

internal sealed class ProductVmdEntityPageVmd:BaseNotGenericEntityVmdEntityPageVmd<Product>
{
    public ProductVmdEntityPageVmd(IRepository<Product> entities) : base(entities)
    {
    }
}