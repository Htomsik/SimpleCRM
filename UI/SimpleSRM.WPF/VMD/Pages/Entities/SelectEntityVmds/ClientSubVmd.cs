using SimpleSRM.DAL.Repositories.Base;
using SimpleSRM.Models.Entities.Actors;
using SimpleSRM.WPF.Services.AppInfrastructure.NavigationServices.TypeNavigationServices;
using SimpleSRM.WPF.VMD.Pages.Entities.SelectEntityVmds.Base;

namespace SimpleSRM.WPF.VMD.Pages.Entities.SelectEntityVmds;

/// <summary>
///     SubEntity vmd тип для Client типа
/// </summary>
internal sealed class ClientSubVmd : BaseSubEntityVmd<Client>
{
    public ClientSubVmd(IRepository<Client> entitiesRepository,
        SubEntityTypeNavigationService closeTypeNavigationService)
        : base(entitiesRepository, closeTypeNavigationService)
    {
    }
}