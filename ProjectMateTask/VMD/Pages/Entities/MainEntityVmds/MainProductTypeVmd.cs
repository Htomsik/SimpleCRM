using ProjectMateTask.DAL.Entities.Actors;
using ProjectMateTask.DAL.Entities.Base;
using ProjectMateTask.DAL.Entities.Types;
using ProjectMateTask.DAL.Repositories;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.TypeNavigationServices;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores;
using ProjectMateTask.VMD.Pages.Entities.MainEntityVmds.Base;

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

    protected override void OnDeleteSubEntityFromCollection(INamedEntity removedEntity) =>  EditableEntity?.Products.Remove((Product)removedEntity);


    protected override void AddSubEntityInCollection(INamedEntity addedEntity) =>  EditableEntity?.Products.Add((Product)addedEntity);
  
}