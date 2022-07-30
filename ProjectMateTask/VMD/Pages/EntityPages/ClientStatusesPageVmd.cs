using ProjectMateTask.DAL.Entities.Types;
using ProjectMateTask.DAL.Repositories;
using ProjectMateTask.VMD.Base;

namespace ProjectMateTask.VMD.Pages.EntityPages;

internal sealed class ClientStatusesPageVmd : BaseEntityPageVmd<ClientStatus>
{
    public ClientStatusesPageVmd(IRepository<ClientStatus> entities) : base(entities)
    {
    }
}