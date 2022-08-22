using ProjectMateTask.DAL.Entities.Actors;
using ProjectMateTask.DAL.Repositories;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices;
using ProjectMateTask.VMD.Pages.SelectEntityVmds.Base;

namespace ProjectMateTask.VMD.Pages.SelectEntityVmds;

internal sealed class ManagerSelectVmd:BaseSelectEntityVmd<Manager>
{
    public ManagerSelectVmd(IRepository<Manager> entitiesRepository, SubEntityNavigationService closeNavigationService) : base(entitiesRepository, closeNavigationService)
    {
    }
}