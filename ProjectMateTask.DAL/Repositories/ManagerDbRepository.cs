using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ProjectMateTask.DAL.Context;
using ProjectMateTask.DAL.Entities.Actors;

namespace ProjectMateTask.DAL.Repositories;

internal sealed class ManagerDbRepository : DbRepository<Manager>
{
    public ManagerDbRepository(ProjectMateTaskDb db) : base(db)
    {
    }

    public override IQueryable<Manager> FullTrackingItems => base.FullTrackingItems
        .Include(item => item.Clients)
        .ThenInclude(item => item.Products)
        .Include(item => item.Clients)
        .ThenInclude(item => item.Status);

    
}