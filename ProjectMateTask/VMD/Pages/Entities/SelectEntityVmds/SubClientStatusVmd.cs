using ProjectMateTask.DAL.Repositories;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.TypeNavigationServices;
using ProjectMateTask.VMD.Pages.Entities.SelectEntityVmds.Base;
using ProjetMateTaskEntities.Entities.Types;

namespace ProjectMateTask.VMD.Pages.Entities.SelectEntityVmds;

/// <summary>
///     SubEntity vmd тип для ClientStatus типа
/// </summary>
internal sealed class SubClientStatusVmd : BaseSubEntityVmd<ClientStatus>
{
    public SubClientStatusVmd(IRepository<ClientStatus> entitiesRepository,
        SubEntityTypeNavigationService closeTypeNavigationService) : base(entitiesRepository,
        closeTypeNavigationService)
    {
    }
}