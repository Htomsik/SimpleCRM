using SimpleSRM.DAL.Repositories.Base;
using SimpleSRM.Models.Entities.Types;
using SimpleSRM.WPF.Services.AppInfrastructure.NavigationServices.TypeNavigationServices;
using SimpleSRM.WPF.VMD.Pages.Entities.SelectEntityVmds.Base;

namespace SimpleSRM.WPF.VMD.Pages.Entities.SelectEntityVmds;

/// <summary>
///     SubEntity vmd тип для ClientStatus типа
/// </summary>
internal sealed class SubClientStatusVmd : BaseSubEntityVmd<ClientStatus>
{
    public SubClientStatusVmd(IRepository<ClientStatus> entitiesRepository,
        SubEntityTypeNavigationService closeTypeNavigationService) : base(entitiesRepository,
        closeTypeNavigationService)
    {
    }
}