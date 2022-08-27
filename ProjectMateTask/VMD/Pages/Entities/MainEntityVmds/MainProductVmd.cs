using ProjectMateTask.DAL.Entities.Actors;
using ProjectMateTask.DAL.Entities.Base;
using ProjectMateTask.DAL.Entities.Types;
using ProjectMateTask.DAL.Repositories;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores;
using ProjectMateTask.VMD.Pages.Entities.MainEntityVmds.Base;

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

    protected override void OnDeleteSubEntityFromCollection(INamedEntity removedEntity)
    {
        EditableEntity.Clients.Remove((Client)removedEntity);
    }

    protected override void AddSubEntityInCollection(INamedEntity AddedEntity)
    {
        EditableEntity.Clients.Add((Client)AddedEntity);
    }

    protected override void ChangeSubEntity(INamedEntity entity)
    {
        if (entity is ProductType) EditableEntity!.Type = (ProductType)entity;
    }
}