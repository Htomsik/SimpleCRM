using System.Linq;
using ProjectMateTask.DAL.Entities.Base;
using ProjectMateTask.DAL.Entities.Types;
using ProjectMateTask.DAL.Repositories;
using ProjectMateTask.VMD.Base;

namespace ProjectMateTask.VMD.Pages.EntityPages;

internal sealed class ClientStatusesPageVmd : BaseEntityPageVmd<ClientStatus>
{
    public ClientStatusesPageVmd(IRepository<ClientStatus> entities) : base(entities)
    {
    }


    protected override void OnDeleteSubEntityFromCollection(object p)
    {
        var deleteitem =  EditableEntity.Clients.First(x => x.Id == ((IEntity)p).Id);

        EditableEntity.Clients.Remove(deleteitem);
    }
}