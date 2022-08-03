using Microsoft.EntityFrameworkCore;
using ProjectMateTask.DAL.Context;
using ProjectMateTask.DAL.Entities.Types;

namespace ProjectMateTask.DAL.Repositories;

internal class ClientStatusDbRepository : DbRepository<ClientStatus>
{
    public ClientStatusDbRepository(ProjectMateTaskDb db) : base(db)
    {
    }

    public override IQueryable<ClientStatus> Items => base.Items.AsNoTrackingWithIdentityResolution()
        .Include(item => item.Clients);
}