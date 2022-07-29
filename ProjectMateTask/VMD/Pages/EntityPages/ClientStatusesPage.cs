using ProjectMateTask.DAL.Entities.Types;
using ProjectMateTask.DAL.Repositories;
using ProjectMateTask.VMD.Base;

namespace ProjectMateTask.VMD.Pages.EntityPages;

internal sealed class ClientStatusesPage : BaseEntityPageVmd<ClientStatus>
{
    public ClientStatusesPage(IRepository<ClientStatus> entities) : base(entities)
    {
    }
}