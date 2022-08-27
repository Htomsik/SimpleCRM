using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectMateTask.DAL.Context;
using ProjectMateTask.DAL.Entities.Actors;

namespace ProjectMateTask.DAL.Repositories;

internal sealed class ManagerDbRepository : DbRepository<Manager>
{
   

    public override IQueryable<Manager> FullTrackingItems => base.FullTrackingItems
        .Include(item => item.Clients)
        .ThenInclude(item => item.Products)
        .Include(item => item.Clients)
        .ThenInclude(item => item.Status);


    public ManagerDbRepository(ProjectMateTaskDb db, ILogger<DbRepository<Manager>> logger) : base(db, logger)
    {
    }
}