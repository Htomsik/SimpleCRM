using SimpleSRM.DAL.Repositories.Base;
using SimpleSRM.Models.Entities.Actors;
using SimpleSRM.Models.Entities.Base;
using SimpleSRM.WPF.Services.AppInfrastructure.NavigationServices.TypeNavigationServices;
using SimpleSRM.WPF.Stores.AppInfrastructure.NavigationStores;
using SimpleSRM.WPF.VMD.Pages.Entities.MainEntityVmds.Base;

namespace SimpleSRM.WPF.VMD.Pages.Entities.MainEntityVmds;

/// <summary>
///     MainEntity vmd тип для Manager типа
/// </summary>
internal sealed class MainManagerVmd : BaseMainEntityVmd<Manager>
{
    public MainManagerVmd(
        IRepository<Manager> entitiesRepository,
        SubEntityTypeNavigationService selectedSubEntityTypeNavigationService,
        SubEntityVmdNavigationStore subEntityVmdSubEntityVmdSubEntityVmdNavigationStore)
        : base(
            entitiesRepository,
            selectedSubEntityTypeNavigationService,
            subEntityVmdSubEntityVmdSubEntityVmdNavigationStore)
    {
    }

    public override string Tittle  => "Менеджеры";

    protected override void OnDeleteSubEntityFromCollection(INamedEntity removedEntity) => EditableEntity?.Clients.Remove((Client)removedEntity);
   

    protected override void AddSubEntityInCollection(INamedEntity addedEntity) => EditableEntity?.Clients.Add((Client)addedEntity);
  
}