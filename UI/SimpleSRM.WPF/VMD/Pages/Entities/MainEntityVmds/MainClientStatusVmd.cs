using SimpleSRM.DAL.Repositories.Base;
using SimpleSRM.Models.Entities.Actors;
using SimpleSRM.Models.Entities.Base;
using SimpleSRM.Models.Entities.Types;
using SimpleSRM.WPF.Services.AppInfrastructure.NavigationServices.TypeNavigationServices;
using SimpleSRM.WPF.Stores.AppInfrastructure.NavigationStores;
using SimpleSRM.WPF.VMD.Pages.Entities.MainEntityVmds.Base;

namespace SimpleSRM.WPF.VMD.Pages.Entities.MainEntityVmds;

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
    
    public override string Tittle  => "Статусы клиентов";

    protected override void OnDeleteSubEntityFromCollection(INamedEntity removedEntity) =>  EditableEntity?.Clients.Remove((Client)removedEntity);
    
    protected override void AddSubEntityInCollection(INamedEntity addedEntity) =>  EditableEntity?.Clients.Add((Client)addedEntity);
    
}