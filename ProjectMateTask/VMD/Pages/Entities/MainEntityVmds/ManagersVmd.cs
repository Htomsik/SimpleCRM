using ProjectMateTask.DAL.Entities.Actors;
using ProjectMateTask.DAL.Entities.Base;
using ProjectMateTask.DAL.Repositories;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores;
using ProjectMateTask.VMD.Pages.Entities.MainEntityVmds.Base;

namespace ProjectMateTask.VMD.Pages.Entities.MainEntityVmds;

internal sealed class ManagersVmd:BaseEntityVmd<Manager>
{
    

    protected override void OnDeleteSubEntityFromCollection(object p) => EditableEntity.Clients.Remove((Client)p);
    
    protected override void AddSubEntityInCollection(INamedEntity entity)=> EditableEntity.Clients.Add((Client)entity);
    


    public ManagersVmd(
        IRepository<Manager?> entitiesRepository,
        SubEntityTypeNavigationService selectedSubEntityTypeNavigationService,
        SubEntityNavigationStore subSubEntitySubNavigationStore ) 
        : base(
            entitiesRepository, 
            selectedSubEntityTypeNavigationService, 
            subSubEntitySubNavigationStore){}
}