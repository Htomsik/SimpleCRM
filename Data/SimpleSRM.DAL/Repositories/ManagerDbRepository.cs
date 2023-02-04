using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimpleSRM.DAL.Context;
using SimpleSRM.DAL.Repositories.Base;
using SimpleSRM.Models.Entities.Actors;

namespace SimpleSRM.DAL.Repositories;

internal sealed class ManagerDbRepository : DbRepository<Manager>
{
   

    public override IQueryable<Manager> FullTrackingItems => base.FullTrackingItems
        .Include(item => item.Clients)
        .ThenInclude(item => item.Products)
        .Include(item => item.Clients)
        .ThenInclude(item => item.Status);


    public ManagerDbRepository(DataDb db, ILogger<DbRepository<Manager>> logger) : base(db, logger)
    {
    }
}