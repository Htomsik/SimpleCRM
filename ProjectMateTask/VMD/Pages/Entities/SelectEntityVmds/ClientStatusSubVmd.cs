using ProjectMateTask.DAL.Entities.Types;
using ProjectMateTask.DAL.Repositories;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices;
using ProjectMateTask.VMD.Pages.Entities.SelectEntityVmds.Base;

namespace ProjectMateTask.VMD.Pages.Entities.SelectEntityVmds;

internal sealed class ClientStatusSubVmd : BaseSubEntityVmd<ClientStatus>
{
    public ClientStatusSubVmd(IRepository<ClientStatus> entitiesRepository, SubEntityTypeNavigationService closeTypeNavigationService) : base(entitiesRepository, closeTypeNavigationService)
    {
    }
}