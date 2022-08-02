using Microsoft.EntityFrameworkCore;
using ProjectMateTask.DAL.Context;
using ProjectMateTask.DAL.Entities.Actors;
using ProjectMateTask.DAL.Repositories.Base;

namespace ProjectMateTask.DAL.Repositories;

internal sealed class ManagerDbRepository : DbRepository<Manager>
{
    public ManagerDbRepository(ProjectMateTaskDb db) : base(db)
    {
    }

    public override IQueryable<Manager> Items => base.Items.AsNoTrackingWithIdentityResolution()
        .Include(item => item.Clients)
        .ThenInclude(item => item.Products)
        .Include(item => item.Clients)
        .ThenInclude(item => item.Status);
}