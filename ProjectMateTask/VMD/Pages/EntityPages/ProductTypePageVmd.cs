using System.Linq;
using ProjectMateTask.DAL.Entities.Base;
using ProjectMateTask.DAL.Entities.Types;
using ProjectMateTask.DAL.Repositories;
using ProjectMateTask.VMD.Base;

namespace ProjectMateTask.VMD.Pages.EntityPages;

internal sealed class ProductTypePageVmd:BaseEntityPageVmd<ProductType>
{
    public ProductTypePageVmd(IRepository<ProductType> entitiesRepository) : base(entitiesRepository)
    {
    }


    protected override void OnDeleteSubEntityFromCollection(object p)
    {
        var deleteitem =  EditableEntity.Products.First(x => x.Id == ((IEntity)p).Id);

        EditableEntity.Products.Remove(deleteitem);
    }
}