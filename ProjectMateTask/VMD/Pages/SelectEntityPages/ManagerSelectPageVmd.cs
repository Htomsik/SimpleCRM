using ProjectMateTask.DAL.Entities.Actors;
using ProjectMateTask.DAL.Entities.Base;
using ProjectMateTask.DAL.Repositories;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base;
using ProjectMateTask.Stores.Base;
using ProjectMateTask.VMD.Base;

namespace ProjectMateTask.VMD.Pages.SelectEntityPages;

internal sealed class ManagerSelectPageVmd:BaseSelectEntityVmd<Manager>
{
    public ManagerSelectPageVmd(IRepository<Manager> entitiesRepository, SubEntityNavigationServices closeNavigationServices) : base(entitiesRepository, closeNavigationServices)
    {
    }
}