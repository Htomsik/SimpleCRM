using ProjectMateTask.DAL.Entities.Actors;
using ProjectMateTask.DAL.Repositories;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices;
using ProjectMateTask.VMD.Pages.Entities.SelectEntityVmds.Base;

namespace ProjectMateTask.VMD.Pages.Entities.SelectEntityVmds;

internal sealed class ManagerSubVmd:BaseSubEntityVmd<Manager>
{
    public ManagerSubVmd(IRepository<Manager> entitiesRepository, SubEntityTypeNavigationService closeTypeNavigationService) : base(entitiesRepository, closeTypeNavigationService)
    {
    }
}