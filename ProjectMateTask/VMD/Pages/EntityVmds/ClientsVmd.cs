using ProjectMateTask.DAL.Entities.Actors;
using ProjectMateTask.DAL.Entities.Base;
using ProjectMateTask.DAL.Entities.Types;
using ProjectMateTask.DAL.Repositories;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores;
using ProjectMateTask.VMD.Pages.EntityVmds.Base;

namespace ProjectMateTask.VMD.Pages.EntityVmds;

internal sealed class ClientsVmd:BaseEntityVmd<Client>
{
    protected override void OnDeleteSubEntityFromCollection(object p) => EditableEntity.Products.Remove((Product)p);
    
    protected override void AddSubEntityInCollection(INamedEntity entity)=> EditableEntity.Products.Add((Product)entity);
    protected override void ChangeSubEntity(INamedEntity entity)
    {
        
        if (entity is ClientStatus)
        {
            EditableEntity!.Status = (ClientStatus)entity;
        }
        else if (entity is Manager)
        {
            EditableEntity!.Manager = (Manager)entity;
        }
     
    }
    
    public ClientsVmd(
        IRepository<Client?> entitiesRepository,
        SubEntityNavigationService selectedSubEntityNavigationService,
        SubEntityNavigationStore subSubEntitySubNavigationStore) 
        : base(
            entitiesRepository, 
            selectedSubEntityNavigationService, 
            subSubEntitySubNavigationStore){}
    
}