using Microsoft.EntityFrameworkCore;
using ProjectMateTask.DAL.Context;
using ProjectMateTask.DAL.Entities.Actors;

namespace ProjectMateTask.DAL.Repositories;

internal sealed class ClientDbRepository : DbRepository<Client>
{
    public ClientDbRepository(ProjectMateTaskDb db) : base(db)
    {
    }

    public override IQueryable<Client> Items => base.Items.AsNoTrackingWithIdentityResolution()
        .Include(item => item.Manager)
        .Include(item => item.Status)
        .Include(item => item.Products)
        .ThenInclude(item => item.Type);
}