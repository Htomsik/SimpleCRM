using System.Linq;
using ProjectMateTask.DAL.Entities;
using ProjectMateTask.DAL.Entities.Actors;
using ProjectMateTask.DAL.Entities.Base;
using ProjectMateTask.DAL.Repositories;
using ProjectMateTask.VMD.Base;

namespace ProjectMateTask.VMD.Pages.EntityPages;

internal sealed class ProductPageVmd:BaseEntityPageVmd<Product>
{
    public ProductPageVmd(IRepository<Product> entities) : base(entities)
    {
    }


    protected override void OnDeleteSubEntityFromCollection(object p)
    {
        var deleteitem =  EditableEntity.Clients.First(x => x.Id == ((IEntity)p).Id);

        EditableEntity.Clients.Remove(deleteitem);
    }
}