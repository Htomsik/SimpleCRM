using System.Collections.Generic;
using System.Linq;
using ProjectMateTask.DAL.Entities;
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

internal sealed class ManagersPageVmd:BaseEntityPageVmd<Manager>
{
    

    protected override void OnDeleteSubEntityFromCollection(object p) => EditableEntity.Clients.Remove((Client)p);
    
    protected override void AddSubEntityInCollection(INamedEntity entity)=> EditableEntity.Clients.Add((Client)entity);
    


    public ManagersPageVmd(
        IRepository<Manager?> entitiesRepository,
        SubEntityNavigationServices selectedSubEntityNavigationServices,
        EntityPageNavigationStore selectedEntityNavigationStore ) 
        : base(
            entitiesRepository, 
            selectedSubEntityNavigationServices, 
            selectedEntityNavigationStore){}
}