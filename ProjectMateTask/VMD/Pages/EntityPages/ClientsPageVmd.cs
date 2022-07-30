using ProjectMateTask.DAL.Entities;
using ProjectMateTask.DAL.Entities.Actors;
using ProjectMateTask.DAL.Repositories;
using ProjectMateTask.VMD.Base;

namespace ProjectMateTask.VMD.Pages.EntityPages;

internal sealed class ClientsVmdEntityPageVmd:BaseNotGenericEntityVmdEntityPageVmd<Client>
{
    public ClientsVmdEntityPageVmd(IRepository<Client> entities) : base(entities)
    {
    }
}