using System.Collections.Generic;
using System.Linq;
using ProjectMateTask.DAL.Entities.Actors;
using ProjectMateTask.DAL.Entities.Base;
using ProjectMateTask.DAL.Entities.Types;
using ProjectMateTask.DAL.Repositories;
using ProjectMateTask.DAL.Services;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores.Base;
using ProjectMateTask.Stores.Base;

using ProjectMateTask.VMD.Base;

namespace ProjectMateTask.VMD.Pages.EntityPages;

internal sealed class ProductTypePageVmd:BaseEntityPageVmd<ProductType>
{
    
    protected override void OnDeleteSubEntityFromCollection(object p) => EditableEntity.Products.Remove((Product)p);
    
    protected override void AddSubEntityInCollection(INamedEntity entity)=> EditableEntity.Products.Add((Product)entity);
    


    public ProductTypePageVmd(
        IRepository<ProductType?> entitiesRepository,
        SubEntityNavigationServices selectedSubEntityNavigationServices,
        EntityPageNavigationStore selectedEntityNavigationStore ) 
        : base(
            entitiesRepository, 
            selectedSubEntityNavigationServices, 
            selectedEntityNavigationStore){}
}