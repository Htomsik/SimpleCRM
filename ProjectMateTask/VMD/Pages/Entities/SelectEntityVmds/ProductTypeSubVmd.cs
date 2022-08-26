using ProjectMateTask.DAL.Entities.Types;
using ProjectMateTask.DAL.Repositories;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices;
using ProjectMateTask.VMD.Pages.Entities.SelectEntityVmds.Base;

namespace ProjectMateTask.VMD.Pages.Entities.SelectEntityVmds;

internal sealed class ProductTypeSubVmd:BaseSubEntityVmd<ProductType>
{
    public ProductTypeSubVmd(IRepository<ProductType> entitiesRepository, SubEntityTypeNavigationService closeTypeNavigationService) : base(entitiesRepository, closeTypeNavigationService)
    {
    }
}