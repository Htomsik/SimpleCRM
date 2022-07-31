using Microsoft.EntityFrameworkCore;
using ProjectMateTask.DAL.Context;
using ProjectMateTask.DAL.Entities.Actors;
using ProjectMateTask.DAL.Repositories.Base;

namespace ProjectMateTask.DAL.Repositories;

internal sealed class ManagerRepository : DbRepository<Manager>
{
    public ManagerRepository(ProjectMateTaskDb db) : base(db)
    {
    }

    public override IQueryable<Manager> Items => base.Items
        .Include(item => item.Clients)
        .ThenInclude(item => item.Products)
        .Include(item => item.Clients)
        .ThenInclude(item => item.Status);
}