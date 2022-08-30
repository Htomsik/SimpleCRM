using ProjectMateTask.VMD.Base;
using ProjectMateTask.VMD.Pages.Entities.Base;

namespace ProjectMateTask.Stores.AppInfrastructure.NavigationStores.Base;

/// <summary>
///     Базовая реализация навигационного хрнилища для EntityVmd типов
/// </summary>
/// <typeparam name="TEntity">Любой EntityVmd тип</typeparam>
public class BaseEntityVmdNavigationStore<TEntity> : BaseVmdNavigationStore<TEntity>, IEntityVmdNavigationStore<TEntity> where TEntity : BaseVmd, IEntityVmd
{
    
}