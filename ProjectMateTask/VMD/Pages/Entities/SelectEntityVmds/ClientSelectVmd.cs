using ProjectMateTask.DAL.Entities.Actors;
using ProjectMateTask.DAL.Repositories;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices;
using ProjectMateTask.VMD.Pages.Entities.SelectEntityVmds.Base;

namespace ProjectMateTask.VMD.Pages.Entities.SelectEntityVmds;

internal sealed class ClientSelectVmd:BaseSelectEntityVmd<Client>
{
    public ClientSelectVmd(IRepository<Client> entitiesRepository, SubEntityTypeNavigationService closeTypeNavigationService) 
        : base(entitiesRepository, closeTypeNavigationService)
    {
    }
}