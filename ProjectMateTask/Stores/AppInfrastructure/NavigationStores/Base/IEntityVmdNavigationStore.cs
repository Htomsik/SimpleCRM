using ProjectMateTask.Stores.Base;
using ProjectMateTask.VMD.Base;
using ProjectMateTask.VMD.Pages.Entities.Base;

namespace ProjectMateTask.Stores.AppInfrastructure.NavigationStores.Base;

internal interface IEntityVmdNavigationStore<TEntityVmd> : IVmdNavigationStore<TEntityVmd> where TEntityVmd : BaseVmd, IEntityVmd
{
    
}