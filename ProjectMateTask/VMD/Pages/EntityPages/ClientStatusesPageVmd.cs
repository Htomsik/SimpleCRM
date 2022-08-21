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

internal sealed class ClientStatusesPageVmd : BaseEntityPageVmd<ClientStatus>
{
    protected override void OnDeleteSubEntityFromCollection(object p) => EditableEntity!.Clients.Remove((Client)p);
    
    protected override void AddSubEntityInCollection(INamedEntity entity)=> EditableEntity!.Clients.Add((Client)entity);
   
    
    public ClientStatusesPageVmd(
        IRepository<ClientStatus?> entitiesRepository,
        SubEntityNavigationService selectedSubEntityNavigationService,
        EntityPageSubNavigationStore selectedEntitySubNavigationStore ) 
        : base(
            entitiesRepository, 
            selectedSubEntityNavigationService, 
            selectedEntitySubNavigationStore){}
}