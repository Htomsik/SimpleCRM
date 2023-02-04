using SimpleSRM.DAL.Repositories.Base;
using SimpleSRM.Models.Entities.Actors;
using SimpleSRM.WPF.Services.AppInfrastructure.NavigationServices.TypeNavigationServices;
using SimpleSRM.WPF.VMD.Pages.Entities.SelectEntityVmds.Base;

namespace SimpleSRM.WPF.VMD.Pages.Entities.SelectEntityVmds;

/// <summary>
///     SubEntity vmd тип для Manager типа
/// </summary>
internal sealed class SubManagerVmd : BaseSubEntityVmd<Manager>
{
    public SubManagerVmd(IRepository<Manager> entitiesRepository,
        SubEntityTypeNavigationService closeTypeNavigationService) : base(entitiesRepository,
        closeTypeNavigationService)
    {
    }
}