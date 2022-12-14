using ProjectMateTask.DAL.Repositories;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.TypeNavigationServices;
using ProjectMateTask.VMD.Pages.Entities.SelectEntityVmds.Base;
using ProjetMateTaskEntities.Entities.Actors;

namespace ProjectMateTask.VMD.Pages.Entities.SelectEntityVmds;

/// <summary>
///     SubEntity vmd тип для Manager типа
/// </summary>
internal sealed class SubManagerVmd : BaseSubEntityVmd<Manager>
{
    public SubManagerVmd(IRepository<Manager> entitiesRepository,
        SubEntityTypeNavigationService closeTypeNavigationService) : base(entitiesRepository,
        closeTypeNavigationService)
    {
    }
}