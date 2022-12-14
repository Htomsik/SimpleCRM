using ProjectMateTask.DAL.Repositories;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.TypeNavigationServices;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores;
using ProjectMateTask.VMD.Pages.Entities.MainEntityVmds.Base;
using ProjetMateTaskEntities.Entities.Actors;
using ProjetMateTaskEntities.Entities.Base;
using ProjetMateTaskEntities.Entities.Types;

namespace ProjectMateTask.VMD.Pages.Entities.MainEntityVmds;

/// <summary>
///     MainEntity vmd тип для ProductType типа
/// </summary>
internal sealed class MainProductTypeVmd : BaseMainEntityVmd<ProductType>
{
    public MainProductTypeVmd(
        IRepository<ProductType> entitiesRepository,
        SubEntityTypeNavigationService selectedSubEntityTypeNavigationService,
        SubEntityVmdNavigationStore subEntityVmdSubEntityVmdSubEntityVmdNavigationStore)
        : base(
            entitiesRepository,
            selectedSubEntityTypeNavigationService,
            subEntityVmdSubEntityVmdSubEntityVmdNavigationStore)
    {
    }

    public override string Tittle  => "Типы продуктов";
    
    protected override void OnDeleteSubEntityFromCollection(INamedEntity removedEntity) =>  EditableEntity?.Products.Remove((Product)removedEntity);


    protected override void AddSubEntityInCollection(INamedEntity addedEntity) =>  EditableEntity?.Products.Add((Product)addedEntity);
  
}