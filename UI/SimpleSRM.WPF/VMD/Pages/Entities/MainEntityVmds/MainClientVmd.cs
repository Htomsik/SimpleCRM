using SimpleSRM.DAL.Repositories.Base;
using SimpleSRM.Models.Entities.Actors;
using SimpleSRM.Models.Entities.Base;
using SimpleSRM.Models.Entities.Types;
using SimpleSRM.WPF.Services.AppInfrastructure.NavigationServices.TypeNavigationServices;
using SimpleSRM.WPF.Stores.AppInfrastructure.NavigationStores;
using SimpleSRM.WPF.VMD.Pages.Entities.MainEntityVmds.Base;

namespace SimpleSRM.WPF.VMD.Pages.Entities.MainEntityVmds;

/// <summary>
///     MainEntity vmd тип для Client типа
/// </summary>
internal sealed class MainClientVmd : BaseMainEntityVmd<Client>
{
    public MainClientVmd(
        IRepository<Client> entitiesRepository,
        SubEntityTypeNavigationService selectedSubEntityTypeNavigationService,
        SubEntityVmdNavigationStore subEntityVmdSubEntityVmdSubEntityVmdNavigationStore)
        : base(
            entitiesRepository,
            selectedSubEntityTypeNavigationService,
            subEntityVmdSubEntityVmdSubEntityVmdNavigationStore)
    {
    }

    public override string Tittle  => "Клиенты";

    protected override void OnDeleteSubEntityFromCollection(INamedEntity removedEntity) => EditableEntity?.Products.Remove((Product)removedEntity);
  

    protected override void AddSubEntityInCollection(INamedEntity addedEntity) => EditableEntity?.Products.Add((Product)addedEntity);
   

    protected override void ChangeSubEntity(INamedEntity subEntity)
    {
        if (subEntity is ClientStatus)
            EditableEntity!.Status = (ClientStatus)subEntity;
        else if (subEntity is Manager) EditableEntity!.Manager = (Manager)subEntity;
    }
}