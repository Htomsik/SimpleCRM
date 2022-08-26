using ProjectMateTask.DAL.Entities.Actors;
using ProjectMateTask.DAL.Entities.Base;
using ProjectMateTask.DAL.Entities.Types;
using ProjectMateTask.DAL.Repositories;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores;
using ProjectMateTask.VMD.Pages.Entities.MainEntityVmds.Base;

namespace ProjectMateTask.VMD.Pages.Entities.MainEntityVmds;

internal sealed class ProductsVmd:BaseMainEntityVmd<Product>
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


    public ProductsVmd(
        IRepository<Product?> entitiesRepository,
        SubEntityTypeNavigationService selectedSubEntityTypeNavigationService,
        SubEntityVmdNavigationStore subEntityVmdSubEntityVmdSubEntityVmdNavigationStore) 
        : base(
            entitiesRepository, 
            selectedSubEntityTypeNavigationService, 
            subEntityVmdSubEntityVmdSubEntityVmdNavigationStore){}
}