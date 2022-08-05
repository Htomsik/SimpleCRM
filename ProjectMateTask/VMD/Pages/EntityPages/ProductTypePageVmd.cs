using System.Collections.Generic;
using System.Linq;
using ProjectMateTask.DAL.Entities.Actors;
using ProjectMateTask.DAL.Entities.Base;
using ProjectMateTask.DAL.Entities.Services;
using ProjectMateTask.DAL.Entities.Types;
using ProjectMateTask.DAL.Repositories;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores.Base;
using ProjectMateTask.Stores.Base;

using ProjectMateTask.VMD.Base;

namespace ProjectMateTask.VMD.Pages.EntityPages;

internal sealed class ProductTypePageVmd:BaseEntityPageVmd<ProductType>
{
    
    protected override void OnDeleteSubEntityFromCollection(object p)
    {
        var deleteitem =  EditableEntity.Products.First(x => x.Id == ((IEntity)p).Id);

        EditableEntity.Products.Remove(deleteitem);
    }
    
    protected override void OnAddSubEntity(INamedEntity entity)
    {
        var foundEntity = EntityServices<Product>.FindElemByIdInCollection(EditableEntity.Products, entity.Id);

        if (foundEntity is not null) return;
       
        EditableEntity.Products.Add((Product)entity);
        
    }

    public ProductTypePageVmd(
        IRepository<ProductType> entitiesRepository,
        EntityPageNavigationServices selectedEntityPageNavigationServices,
        EntityPageNavigationStore selectedEntityNavigationStore ) 
        : base(
            entitiesRepository, 
            selectedEntityPageNavigationServices, 
            selectedEntityNavigationStore){}
}