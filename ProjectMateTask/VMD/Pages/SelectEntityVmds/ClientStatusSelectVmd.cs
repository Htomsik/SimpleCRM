using ProjectMateTask.DAL.Entities.Types;
using ProjectMateTask.DAL.Repositories;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices;
using ProjectMateTask.VMD.Pages.SelectEntityVmds.Base;

namespace ProjectMateTask.VMD.Pages.SelectEntityVmds;

internal sealed class ClientStatusSelectVmd : BaseSelectEntityVmd<ClientStatus>
{
    public ClientStatusSelectVmd(IRepository<ClientStatus> entitiesRepository, SubEntityNavigationService closeNavigationService) : base(entitiesRepository, closeNavigationService)
    {
    }
}