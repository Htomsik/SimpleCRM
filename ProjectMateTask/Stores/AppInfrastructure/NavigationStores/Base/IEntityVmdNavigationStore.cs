using ProjectMateTask.VMD.Base;
using ProjectMateTask.VMD.Pages.Entities.Base;

namespace ProjectMateTask.Stores.AppInfrastructure.NavigationStores.Base;

/// <summary>
///     Навигаионное хранилище для EntityVmd типов
/// </summary>
/// <typeparam name="TEntityVmd">Любой EntityVmd тип</typeparam>
internal interface IEntityVmdNavigationStore<TEntityVmd> : IVmdNavigationStore<TEntityVmd>
    where TEntityVmd : BaseVmd, IEntityVmd
{
}