using ProjectMateTask.DAL.Repositories;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.TypeNavigationServices;
using ProjectMateTask.VMD.Pages.Entities.SelectEntityVmds.Base;
using ProjetMateTaskEntities.Entities.Types;

namespace ProjectMateTask.VMD.Pages.Entities.SelectEntityVmds;

/// <summary>
///     SubEntity vmd тип для ProductType типа
/// </summary>
internal sealed class SubProductTypeVmd : BaseSubEntityVmd<ProductType>
{
    public SubProductTypeVmd(IRepository<ProductType> entitiesRepository,
        SubEntityTypeNavigationService closeTypeNavigationService) : base(entitiesRepository,
        closeTypeNavigationService)
    {
    }
}