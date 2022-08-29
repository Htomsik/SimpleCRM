using ProjectMateTask.DAL.Repositories;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.TypeNavigationServices;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores;
using ProjectMateTask.VMD.Pages.Entities.MainEntityVmds.Base;
using ProjetMateTaskEntities.Entities.Actors;
using ProjetMateTaskEntities.Entities.Base;
using ProjetMateTaskEntities.Entities.Types;

namespace ProjectMateTask.VMD.Pages.Entities.MainEntityVmds;

/// <summary>
///     MainEntity vmd тип для Product типа
/// </summary>
internal sealed class MainProductVmd : BaseMainEntityVmd<Product>
{
    public MainProductVmd(
        IRepository<Product> entitiesRepository,
        SubEntityTypeNavigationService selectedSubEntityTypeNavigationService,
        SubEntityVmdNavigationStore subEntityVmdSubEntityVmdSubEntityVmdNavigationStore)
        : base(
            entitiesRepository,
            selectedSubEntityTypeNavigationService,
            subEntityVmdSubEntityVmdSubEntityVmdNavigationStore)
    {
    }

    protected override void OnDeleteSubEntityFromCollection(INamedEntity removedEntity) => EditableEntity?.Clients.Remove((Client)removedEntity);
  

    protected override void AddSubEntityInCollection(INamedEntity addedEntity) =>  EditableEntity?.Clients.Add((Client)addedEntity);
   

    protected override void ChangeSubEntity(INamedEntity subEntity)
    {
        if (subEntity is ProductType) EditableEntity!.Type = (ProductType)subEntity;
    }
}