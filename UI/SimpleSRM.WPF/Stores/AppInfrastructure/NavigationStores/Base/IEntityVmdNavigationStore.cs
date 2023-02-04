using SimpleSRM.WPF.VMD.Base;
using SimpleSRM.WPF.VMD.Pages.Entities.Base;

namespace SimpleSRM.WPF.Stores.AppInfrastructure.NavigationStores.Base;

/// <summary>
///     Навигаионное хранилище для EntityVmd типов
/// </summary>
/// <typeparam name="TEntityVmd">Любой EntityVmd тип</typeparam>
internal interface IEntityVmdNavigationStore<TEntityVmd> : IVmdNavigationStore<TEntityVmd>
    where TEntityVmd : BaseVmd, IEntityVmd
{
}