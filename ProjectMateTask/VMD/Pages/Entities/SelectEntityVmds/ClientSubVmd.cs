using ProjectMateTask.DAL.Entities.Actors;
using ProjectMateTask.DAL.Repositories;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.TypeNavigationServices;
using ProjectMateTask.VMD.Pages.Entities.SelectEntityVmds.Base;

namespace ProjectMateTask.VMD.Pages.Entities.SelectEntityVmds;

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