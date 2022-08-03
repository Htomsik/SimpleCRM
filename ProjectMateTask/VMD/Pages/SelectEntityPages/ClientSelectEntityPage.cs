using ProjectMateTask.DAL.Entities.Actors;
using ProjectMateTask.DAL.Entities.Base;
using ProjectMateTask.DAL.Repositories;
using ProjectMateTask.Stores.Base;
using ProjectMateTask.VMD.Base;

namespace ProjectMateTask.VMD.Pages.SelectEntityPages;

internal sealed class ClientSelectEntityPage:BaseSelectEntityVmd<Client>
{
    public ClientSelectEntityPage(IRepository<Client> entitiesRepository, IReadOnlyCollectionStore<IEntity> subReadOnlyCollectionStore) : base(entitiesRepository, subReadOnlyCollectionStore)
    {
    }
}