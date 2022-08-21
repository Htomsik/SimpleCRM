using System;
using System.Collections.Generic;
using ProjectMateTask.DAL.Entities.Actors;
using ProjectMateTask.DAL.Entities.Types;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.TyeNavigationServices;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores.Base;
using ProjectMateTask.VMD.Base;
using ProjectMateTask.VMD.Pages.EntityPages;
using ProjectMateTask.VMD.Pages.SelectEntityPages;
using ProjectMateTask.VMD.Pages.SelectEntityPages.Base;

namespace ProjectMateTask.Services.AppInfrastructure.NavigationServices;

internal sealed class SubEntityNavigationService: BaseTypeNavigationServices<BaseNotGenericSubEntityVmd>
{
    public SubEntityNavigationService(INavigationStore<BaseNotGenericSubEntityVmd> navigationStore) : base(navigationStore)
    {
    }
    
    private static readonly Dictionary<Type,Type> VmdTypes = new()
    {
        {typeof(Client),typeof(ClientSelectPageVmd)},
        {typeof(Product),typeof(ProductSelectPageVmd)},
        {typeof(Manager),typeof(ManagerSelectPageVmd)},
        {typeof(ProductType),typeof(ProductTypeSelectPageVmd)},
        {typeof(ClientStatus),typeof(ClientStatusSelectPageVmd)}
    };

    public override void Navigate(Type entityType)
    {
        Type vmdType;
        
        try
        {
            vmdType = VmdTypes[entityType];

        }
        catch (Exception)
        {
            throw new ArgumentOutOfRangeException($"Не найдено SelectEntity страницы для {entityType}");
        }
       
        
        base.Navigate(vmdType);
    }
}