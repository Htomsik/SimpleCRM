using System.Linq;
using Mapster;
using ProjectMateTask.DAL.Entities;
using ProjectMateTask.DAL.Entities.Actors;
using ProjectMateTask.DAL.Entities.Base;
using ProjectMateTask.DAL.Repositories;
using ProjectMateTask.VMD.Base;

namespace ProjectMateTask.VMD.Pages.EntityPages;

internal sealed class ClientsPageVmd:BaseEntityPageVmd<Client>
{
    public ClientsPageVmd(IRepository<Client> entities) : base(entities)
    {
    }

    protected override void OnDeleteSubEntityFromCollection(object p)
    {
        
     var deleteitem =  EditableEntity.Products.First(x => x.Id == ((IEntity)p).Id);

     EditableEntity.Products.Remove(deleteitem);

    }
    
}