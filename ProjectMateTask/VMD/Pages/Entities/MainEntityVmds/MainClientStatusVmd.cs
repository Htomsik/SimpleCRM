using ProjectMateTask.DAL.Entities.Actors;
using ProjectMateTask.DAL.Entities.Base;
using ProjectMateTask.DAL.Entities.Types;
using ProjectMateTask.DAL.Repositories;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.TypeNavigationServices;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores;
using ProjectMateTask.VMD.Pages.Entities.MainEntityVmds.Base;

namespace ProjectMateTask.VMD.Pages.Entities.MainEntityVmds;

/// <summary>
///     MainEntity vmd тип для ClientStatus типа
/// </summary>
internal sealed class MainClientStatusVmd : BaseMainEntityVmd<ClientStatus>
{
    public MainClientStatusVmd(
        IRepository<ClientStatus> entitiesRepository,
        SubEntityTypeNavigationService selectedSubEntityTypeNavigationService,
        SubEntityVmdNavigationStore subEntityVmdSubEntityVmdSubEntityVmdNavigationStore)
        : base(
            entitiesRepository,
            selectedSubEntityTypeNavigationService,
            subEntityVmdSubEntityVmdSubEntityVmdNavigationStore)
    {
    }

    protected override void OnDeleteSubEntityFromCollection(INamedEntity removedEntity) =>  EditableEntity?.Clients.Remove((Client)removedEntity);
    
    protected override void AddSubEntityInCollection(INamedEntity addedEntity) =>  EditableEntity?.Clients.Add((Client)addedEntity);
    
}