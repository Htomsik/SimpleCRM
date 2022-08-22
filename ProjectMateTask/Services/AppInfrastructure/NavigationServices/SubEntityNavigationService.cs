using System;
using System.Collections.Generic;
using ProjectMateTask.DAL.Entities.Actors;
using ProjectMateTask.DAL.Entities.Types;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.TyeNavigationServices;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores.Base;
using ProjectMateTask.VMD.Base;
using ProjectMateTask.VMD.Pages.SelectEntityVmds;
using ProjectMateTask.VMD.Pages.SelectEntityVmds.Base;

namespace ProjectMateTask.Services.AppInfrastructure.NavigationServices;

internal sealed class SubEntityNavigationService: BaseTypeNavigationServices<BaseNotGenericSubEntityVmd>
{
    public SubEntityNavigationService(INavigationStore<BaseNotGenericSubEntityVmd> navigationStore) : base(navigationStore)
    {
    }
    
    private static readonly Dictionary<Type,Type> VmdTypes = new()
    {
        {typeof(Client),typeof(ClientSelectVmd)},
        {typeof(Product),typeof(ProductSelectVmd)},
        {typeof(Manager),typeof(ManagerSelectVmd)},
        {typeof(ProductType),typeof(ProductTypeSelectVmd)},
        {typeof(ClientStatus),typeof(ClientStatusSelectVmd)}
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