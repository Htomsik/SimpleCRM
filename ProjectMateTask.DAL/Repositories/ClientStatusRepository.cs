using Microsoft.EntityFrameworkCore;
using ProjectMateTask.DAL.Context;
using ProjectMateTask.DAL.Entities.Types;
using ProjectMateTask.DAL.Repositories.Base;

namespace ProjectMateTask.DAL.Repositories;

internal class ClientStatusRepository:DbRepository<ClientStatus>
{
    public override IQueryable<ClientStatus> Items => base.Items
        .Include(item => item.Clients);

    public ClientStatusRepository(ProjectMateTaskDb db) : base(db)
    {
    }
}