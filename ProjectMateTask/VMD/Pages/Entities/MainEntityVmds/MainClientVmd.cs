using ProjectMateTask.DAL.Entities.Actors;
using ProjectMateTask.DAL.Entities.Base;
using ProjectMateTask.DAL.Entities.Types;
using ProjectMateTask.DAL.Repositories;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores;
using ProjectMateTask.VMD.Pages.Entities.MainEntityVmds.Base;

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

    protected override void OnDeleteSubEntityFromCollection(INamedEntity removedEntity)
    {
        EditableEntity.Products.Remove((Product)removedEntity);
    }

    protected override void AddSubEntityInCollection(INamedEntity AddedEntity)
    {
        EditableEntity.Products.Add((Product)AddedEntity);
    }

    protected override void ChangeSubEntity(INamedEntity entity)
    {
        if (entity is ClientStatus)
            EditableEntity!.Status = (ClientStatus)entity;
        else if (entity is Manager) EditableEntity!.Manager = (Manager)entity;
    }
}