using System;
using System.Collections.Generic;
using ProjectMateTask.DAL.Entities.Actors;
using ProjectMateTask.DAL.Entities.Types;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.TypeNavigationServices;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores.Base;
using ProjectMateTask.Stores.Base;
using ProjectMateTask.VMD.Base;
using ProjectMateTask.VMD.Pages.Entities.Base;
using ProjectMateTask.VMD.Pages.Entities.SelectEntityVmds;
using ProjectMateTask.VMD.Pages.Entities.SelectEntityVmds.Base;

namespace ProjectMateTask.Services.AppInfrastructure.NavigationServices;

/// <summary>
///     Метод навигации между связными Entity 
/// </summary>
internal sealed class SubEntityTypeNavigationService: BaseTypeNavigationServices<BaseEntityVmd>
{
    public SubEntityTypeNavigationService(IVmdNavigationStore<BaseEntityVmd> vmdNavigationStore) : base(vmdNavigationStore)
    {
    }
    
    /// <summary>
    /// Словарь сапостовления типов
    /// </summary>
    private static readonly Dictionary<Type,Type> VmdTypes = new()
    {
        {typeof(Client),typeof(ClientSubVmd)},
        {typeof(Product),typeof(ProductSubVmd)},
        {typeof(Manager),typeof(ManagerSubVmd)},
        {typeof(ProductType),typeof(ProductTypeSubVmd)},
        {typeof(ClientStatus),typeof(ClientStatusSubVmd)}
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