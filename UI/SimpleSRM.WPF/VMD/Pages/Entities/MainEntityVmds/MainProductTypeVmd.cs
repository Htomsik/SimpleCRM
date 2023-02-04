using SimpleSRM.DAL.Repositories.Base;
using SimpleSRM.Models.Entities.Actors;
using SimpleSRM.Models.Entities.Base;
using SimpleSRM.Models.Entities.Types;
using SimpleSRM.WPF.Services.AppInfrastructure.NavigationServices.TypeNavigationServices;
using SimpleSRM.WPF.Stores.AppInfrastructure.NavigationStores;
using SimpleSRM.WPF.VMD.Pages.Entities.MainEntityVmds.Base;

namespace SimpleSRM.WPF.VMD.Pages.Entities.MainEntityVmds;

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