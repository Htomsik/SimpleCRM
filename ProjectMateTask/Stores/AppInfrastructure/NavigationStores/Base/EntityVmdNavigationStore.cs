using ProjectMateTask.VMD.Base;
using ProjectMateTask.VMD.Pages.Entities.Base;

namespace ProjectMateTask.Stores.AppInfrastructure.NavigationStores.Base;

internal abstract class EntityVmdNavigationStore<TEntity> : BaseVmdNavigationStore<TEntity>, IEntityVmdNavigationStore<TEntity> where TEntity : BaseVmd, IEntityVmd
{
    
}