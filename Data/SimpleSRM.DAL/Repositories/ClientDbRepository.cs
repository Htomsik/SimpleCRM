using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimpleSRM.DAL.Context;
using SimpleSRM.DAL.Repositories.Base;
using SimpleSRM.Models.Entities.Actors;

namespace SimpleSRM.DAL.Repositories;

internal sealed class ClientDbRepository : DbRepository<Client>
{
 

    public override IQueryable<Client> FullTrackingItems => base.FullTrackingItems
        .Include(item => item.Manager)
        .Include(item => item.Status)
        .Include(item => item.Products)
        .ThenInclude(item => item.Type);


    public ClientDbRepository(DataDb db, ILogger<DbRepository<Client>> logger) : base(db, logger)
    {
    }
}