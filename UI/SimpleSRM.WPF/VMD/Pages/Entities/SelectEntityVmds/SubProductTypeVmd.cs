using SimpleSRM.DAL.Repositories.Base;
using SimpleSRM.Models.Entities.Types;
using SimpleSRM.WPF.Services.AppInfrastructure.NavigationServices.TypeNavigationServices;
using SimpleSRM.WPF.VMD.Pages.Entities.SelectEntityVmds.Base;

namespace SimpleSRM.WPF.VMD.Pages.Entities.SelectEntityVmds;

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