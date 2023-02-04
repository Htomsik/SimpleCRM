using SimpleSRM.DAL.Repositories.Base;
using SimpleSRM.Models.Entities.Actors;
using SimpleSRM.WPF.Services.AppInfrastructure.NavigationServices.TypeNavigationServices;
using SimpleSRM.WPF.VMD.Pages.Entities.SelectEntityVmds.Base;

namespace SimpleSRM.WPF.VMD.Pages.Entities.SelectEntityVmds;

/// <summary>
///     SubEntity vmd тип для Product типа
/// </summary>
internal sealed class SubProductVmd : BaseSubEntityVmd<Product>
{
    public SubProductVmd(IRepository<Product> entitiesRepository,
        SubEntityTypeNavigationService closeTypeNavigationService) : base(entitiesRepository,
        closeTypeNavigationService)
    {
    }
}