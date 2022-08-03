using Microsoft.EntityFrameworkCore;
using ProjectMateTask.DAL.Context;
using ProjectMateTask.DAL.Entities.Types;

namespace ProjectMateTask.DAL.Repositories;

internal class ClientStatusDbRepository : DbRepository<ClientStatus>
{
    public ClientStatusDbRepository(ProjectMateTaskDb db) : base(db)
    {
    }

    public override IQueryable<ClientStatus> TrackingItems => base.TrackingItems
        .Include(item => item.Clients);

}