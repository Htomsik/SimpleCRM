using ProjectMateTask.DAL.Entities.Actors;
using ProjectMateTask.DAL.Repositories;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices;
using ProjectMateTask.VMD.Pages.SelectEntityVmds.Base;

namespace ProjectMateTask.VMD.Pages.SelectEntityVmds;

internal sealed class ProductSelectVmd:BaseSelectEntityVmd<Product>
{
    public ProductSelectVmd(IRepository<Product> entitiesRepository, SubEntityNavigationService closeNavigationService) : base(entitiesRepository, closeNavigationService)
    {
    }
}