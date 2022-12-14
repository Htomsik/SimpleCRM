using System;
using System.Collections.Generic;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.TypeNavigationServices;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores.Base;
using ProjectMateTask.VMD.Pages.Entities.Base;
using ProjectMateTask.VMD.Pages.Entities.SelectEntityVmds;
using ProjetMateTaskEntities.Entities.Actors;
using ProjetMateTaskEntities.Entities.Types;

namespace ProjectMateTask.Services.AppInfrastructure.NavigationServices.TypeNavigationServices;

/// <summary>
///     Метод навигации между связными Entity
/// </summary>
internal sealed class SubEntityTypeNavigationService : BaseTypeNavigationServices<BaseEntityVmd>
{
    /// <summary>
    ///     Словарь сопостовления типов Entity с EntityVmd
    /// </summary>
    private static readonly Dictionary<Type, Type> VmdTypes = new()
    {
        { typeof(Client), typeof(ClientSubVmd) },
        { typeof(Product), typeof(SubProductVmd) },
        { typeof(Manager), typeof(SubManagerVmd) },
        { typeof(ProductType), typeof(SubProductTypeVmd) },
        { typeof(ClientStatus), typeof(SubClientStatusVmd) }
    };

    public SubEntityTypeNavigationService(IVmdNavigationStore<BaseEntityVmd> vmdNavigationStore) : base(
        vmdNavigationStore)
    {
    }

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