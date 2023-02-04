using ProjectMateTask.Stores.Base;
using ProjectMateTask.VMD.Base;

namespace ProjectMateTask.Stores.AppInfrastructure.NavigationStores.Base;

/// <summary>
///     Навигационное хранилище для обобщенных vmd типов
/// </summary>
/// <typeparam name="TVmd">Любой тип, наследуемый от BaseVmd</typeparam>
public interface IVmdNavigationStore<TVmd> : IStore<TVmd> where TVmd : BaseVmd
{
}