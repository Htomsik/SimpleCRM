using ProjectMateTask.DAL.Entities.Actors;
using ProjectMateTask.DAL.Entities.Base;
using ProjectMateTask.DAL.Entities.Types;
using ProjectMateTask.DAL.Repositories;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base;
using ProjectMateTask.Stores.Base;
using ProjectMateTask.VMD.Base;

namespace ProjectMateTask.VMD.Pages.SelectEntityPages;

internal sealed class ClientStatusSelectPageVmd : BaseSelectEntityVmd<ClientStatus>
{
    public ClientStatusSelectPageVmd(IRepository<ClientStatus> entitiesRepository, SubEntityNavigationServices closeNavigationServices) : base(entitiesRepository, closeNavigationServices)
    {
    }
}