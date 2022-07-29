using Microsoft.EntityFrameworkCore;
using ProjectMateTask.DAL.Context;
using ProjectMateTask.DAL.Entities;
using ProjectMateTask.DAL.Entities.Actors;
using ProjectMateTask.DAL.Repositories.Base;

namespace ProjectMateTask.DAL.Repositories;

internal sealed class ManagerRepository:DbRepository<Manager>
{
    public override IQueryable<Manager> Items => base.Items
        .Include(item => item.Clients);
    
    public ManagerRepository(ProjectMateTaskDb db) : base(db)
    {
    }
}