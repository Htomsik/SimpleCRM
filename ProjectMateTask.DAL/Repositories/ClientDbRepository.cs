using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectMateTask.DAL.Context;
using ProjectMateTask.DAL.Entities.Actors;

namespace ProjectMateTask.DAL.Repositories;

internal sealed class ClientDbRepository : DbRepository<Client>
{
 

    public override IQueryable<Client> FullTrackingItems => base.FullTrackingItems
        .Include(item => item.Manager)
        .Include(item => item.Status)
        .Include(item => item.Products)
        .ThenInclude(item => item.Type);


    public ClientDbRepository(ProjectMateTaskDb db, ILogger<DbRepository<Client>> logger) : base(db, logger)
    {
    }
}