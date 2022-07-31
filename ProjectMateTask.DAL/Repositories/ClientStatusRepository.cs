using Microsoft.EntityFrameworkCore;
using ProjectMateTask.DAL.Context;
using ProjectMateTask.DAL.Entities.Types;
using ProjectMateTask.DAL.Repositories.Base;

namespace ProjectMateTask.DAL.Repositories;

internal class ClientStatusRepository : DbRepository<ClientStatus>
{
    public ClientStatusRepository(ProjectMateTaskDb db) : base(db)
    {
    }

    public override IQueryable<ClientStatus> Items => base.Items
        .Include(item => item.Clients);
}