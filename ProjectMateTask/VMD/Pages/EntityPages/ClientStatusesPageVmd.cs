using ProjectMateTask.DAL.Entities.Types;
using ProjectMateTask.DAL.Repositories;
using ProjectMateTask.VMD.Base;

namespace ProjectMateTask.VMD.Pages.EntityPages;

internal sealed class ClientStatusesVmdEntityPageVmd : BaseNotGenericEntityVmdEntityPageVmd<ClientStatus>
{
    public ClientStatusesVmdEntityPageVmd(IRepository<ClientStatus> entities) : base(entities)
    {
    }
}