using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectMateTask.DAL.Context;
using ProjetMateTaskEntities.Entities.Types;

namespace ProjectMateTask.DAL.Repositories;

internal class ClientStatusDbRepository : DbRepository<ClientStatus>
{
   

    public override IQueryable<ClientStatus> FullTrackingItems => base.FullTrackingItems
        .Include(item => item.Clients);

    public ClientStatusDbRepository(ProjectMateTaskDb db, ILogger<DbRepository<ClientStatus>> logger) : base(db, logger)
    {
    }
}