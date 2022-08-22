using ProjectMateTask.DAL.Entities.Actors;
using ProjectMateTask.DAL.Entities.Base;
using ProjectMateTask.DAL.Entities.Types;
using ProjectMateTask.DAL.Repositories;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores;

namespace ProjectMateTask.VMD.Pages.EntityVmds;

internal sealed class ProductTypeVmd:BaseEntityVmd<ProductType>
{
    
    protected override void OnDeleteSubEntityFromCollection(object p) => EditableEntity.Products.Remove((Product)p);
    
    protected override void AddSubEntityInCollection(INamedEntity entity)=> EditableEntity.Products.Add((Product)entity);
    


    public ProductTypeVmd(
        IRepository<ProductType?> entitiesRepository,
        SubEntityNavigationService selectedSubEntityNavigationService,
        SelectedEntityNavigationStore selectedSelectedEntitySelectedNavigationStore ) 
        : base(
            entitiesRepository, 
            selectedSubEntityNavigationService, 
            selectedSelectedEntitySelectedNavigationStore){}
}