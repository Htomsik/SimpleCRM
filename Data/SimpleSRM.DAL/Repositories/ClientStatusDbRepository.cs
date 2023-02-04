using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimpleSRM.DAL.Context;
using SimpleSRM.DAL.Repositories.Base;
using SimpleSRM.Models.Entities.Types;

namespace SimpleSRM.DAL.Repositories;

internal class ClientStatusDbRepository : DbRepository<ClientStatus>
{
   

    public override IQueryable<ClientStatus> FullTrackingItems => base.FullTrackingItems
        .Include(item => item.Clients);

    public ClientStatusDbRepository(DataDb db, ILogger<DbRepository<ClientStatus>> logger) : base(db, logger)
    {
    }
}