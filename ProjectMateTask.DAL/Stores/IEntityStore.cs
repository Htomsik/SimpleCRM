using ProjectMateTask.DAL.Entities.Base;

namespace ProjectMateTask.DAL.Stores;

public interface IEntityStore<TEntity> where TEntity : IEntity
{
     IReadOnlyCollection<TEntity> Entities { get;}

    void Add(TEntity entity);

    void Remove(TEntity entity);
    
    void Remove(int id);
    
    TEntity? Get(TEntity entity);
    
    TEntity? Get(int id);

}