using ProjectMateTask.DAL.Entities.Base;
using ProjectMateTask.DAL.Entities.Types;
using ProjectMateTask.DAL.Repositories;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base;
using ProjectMateTask.Stores.Base;
using ProjectMateTask.VMD.Base;
using ProjectMateTask.VMD.Pages.SelectEntityPages.Base;

namespace ProjectMateTask.VMD.Pages.SelectEntityPages;

internal sealed class ProductTypeSelectPageVmd:BaseSelectEntityVmd<ProductType>
{
    public ProductTypeSelectPageVmd(IRepository<ProductType> entitiesRepository, SubEntityNavigationService closeNavigationService) : base(entitiesRepository, closeNavigationService)
    {
    }
}