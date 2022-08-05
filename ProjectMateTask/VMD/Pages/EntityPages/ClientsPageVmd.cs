using System.Collections.Generic;
using System.Linq;
using Mapster;
using ProjectMateTask.DAL.Entities;
using ProjectMateTask.DAL.Entities.Actors;
using ProjectMateTask.DAL.Entities.Base;
using ProjectMateTask.DAL.Entities.Services;
using ProjectMateTask.DAL.Repositories;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores.Base;
using ProjectMateTask.Stores.Base;

using ProjectMateTask.VMD.Base;

namespace ProjectMateTask.VMD.Pages.EntityPages;

internal sealed class ClientsPageVmd:BaseEntityPageVmd<Client>
{
    protected override void OnDeleteSubEntityFromCollection(object p)
    {
        var deleteItem =  EditableEntity.Products.First(x => x.Id == ((IEntity)p).Id);

        EditableEntity.Products.Remove(deleteItem);
        
    }

    protected override void OnAddSubEntity(INamedEntity entity)
    {
        var foundEntity = EntityServices<Product>.FindElemByIdInCollection(EditableEntity.Products, entity.Id);

       if (foundEntity is not null) return;
       
        EditableEntity.Products.Add((Product)entity);
        
    }
    
    public ClientsPageVmd(
        IRepository<Client> entitiesRepository,
        EntityPageNavigationServices selectedEntityPageNavigationServices,
        EntityPageNavigationStore selectedEntityNavigationStore) 
        : base(
            entitiesRepository, 
            selectedEntityPageNavigationServices, 
            selectedEntityNavigationStore){}
    
}