using ProjectMateTask.DAL.Entities;
using ProjectMateTask.DAL.Entities.Actors;
using ProjectMateTask.DAL.Repositories;
using ProjectMateTask.VMD.Base;

namespace ProjectMateTask.VMD.Pages.EntityPages;

internal sealed class ClientsPageVmd:BaseEntityPageVmd<Client>
{
    public ClientsPageVmd(IRepository<Client> entities) : base(entities)
    {
    }
}