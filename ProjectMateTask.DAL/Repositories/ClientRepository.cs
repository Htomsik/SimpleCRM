using Microsoft.EntityFrameworkCore;
using ProjectMateTask.DAL.Context;
using ProjectMateTask.DAL.Entities.Actors;
using ProjectMateTask.DAL.Repositories.Base;

namespace ProjectMateTask.DAL.Repositories;

internal sealed class ClientRepository : DbRepository<Client>
{
    public ClientRepository(ProjectMateTaskDb db) : base(db)
    {
    }

    public override IQueryable<Client> Items => base.Items
        .Include(item => item.Manager)
        .Include(item => item.Status)
        .Include(item => item.Products)
        .ThenInclude(item => item.Type);
}