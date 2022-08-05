using Microsoft.EntityFrameworkCore;
using ProjectMateTask.DAL.Context;
using ProjectMateTask.DAL.Entities.Types;

namespace ProjectMateTask.DAL.Repositories;

internal class ClientStatusDbRepository : DbRepository<ClientStatus>
{
    public ClientStatusDbRepository(ProjectMateTaskDb db) : base(db)
    {
    }

    public override IQueryable<ClientStatus> FullTrackingItems => base.FullTrackingItems
        .Include(item => item.Clients);

}