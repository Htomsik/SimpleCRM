using ProjectMateTask.DAL.Entities.Actors;
using ProjectMateTask.DAL.Entities.Base;
using ProjectMateTask.DAL.Entities.Types;
using ProjectMateTask.DAL.Repositories;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores;
using ProjectMateTask.VMD.Pages.EntityVmds.Base;

namespace ProjectMateTask.VMD.Pages.EntityVmds;

internal sealed class ProductVmd:BaseEntityVmd<Product>
{
    
    protected override void OnDeleteSubEntityFromCollection(object p) => EditableEntity.Clients.Remove((Client)p);
    
    protected override void AddSubEntityInCollection(INamedEntity entity)=> EditableEntity.Clients.Add((Client)entity);
    protected override void ChangeSubEntity(INamedEntity entity)
    {
        if (entity is ProductType)
        {
            EditableEntity!.Type = (ProductType)entity;
        }
      
    }


    public ProductVmd(
        IRepository<Product?> entitiesRepository,
        SubEntityNavigationService selectedSubEntityNavigationService,
        SubEntityNavigationStore subSubEntitySubNavigationStore) 
        : base(
            entitiesRepository, 
            selectedSubEntityNavigationService, 
            subSubEntitySubNavigationStore){}
}