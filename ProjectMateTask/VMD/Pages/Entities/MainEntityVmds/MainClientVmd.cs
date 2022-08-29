using ProjectMateTask.DAL.Repositories;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.TypeNavigationServices;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores;
using ProjectMateTask.VMD.Pages.Entities.MainEntityVmds.Base;
using ProjetMateTaskEntities.Entities.Actors;
using ProjetMateTaskEntities.Entities.Base;
using ProjetMateTaskEntities.Entities.Types;

namespace ProjectMateTask.VMD.Pages.Entities.MainEntityVmds;

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

    protected override void OnDeleteSubEntityFromCollection(INamedEntity removedEntity) => EditableEntity?.Products.Remove((Product)removedEntity);
  

    protected override void AddSubEntityInCollection(INamedEntity addedEntity) => EditableEntity?.Products.Add((Product)addedEntity);
   

    protected override void ChangeSubEntity(INamedEntity subEntity)
    {
        if (subEntity is ClientStatus)
            EditableEntity!.Status = (ClientStatus)subEntity;
        else if (subEntity is Manager) EditableEntity!.Manager = (Manager)subEntity;
    }
}