using System.Collections.ObjectModel;
using ProjectMateTask.DAL.Entities.Base;

namespace ProjectMateTask.DAL.Stores;

public class BaseEntityStore<TEntity>:IEntityStore<TEntity> where TEntity: IEntity
{
    private ICollection<TEntity> _entities;

    public IReadOnlyCollection<TEntity> Entities
    {
        get => new ObservableCollection<TEntity>(_entities);
    }


    public BaseEntityStore()
    {
        
    }

    public BaseEntityStore(ICollection<TEntity> entities)
    {
        _entities = entities;
    }

    public void Add(TEntity entity)
    {
        var foundEntity = Get(entity.Id);

        if (foundEntity is not null)
            throw new ArgumentException($"Элемент {nameof(entity)} уже присутсвует в {nameof(this.GetType)}");
        
        _entities.Add(entity);
    }

    public void Remove(TEntity entity)
    {
        var foundItem = Get(entity);

        if (foundItem is null)
            throw new ArgumentException($"Элемент {nameof(entity)} отсутсвует в {nameof(this.GetType)}");
        
        _entities.Remove(foundItem);
    }

    public void Remove(int id)
    {
        var foundEntity = Get(id);
        
        if (foundEntity is null)
            throw new ArgumentException($"Элемент c id:{id} отсутсвует в {nameof(this.GetType)}");
        
        _entities.Remove(foundEntity);
    }

    public TEntity? Get(TEntity entity)
    {
        return _entities.FirstOrDefault(el => el.Equals(entity));
    }

    public TEntity? Get(int id)
    {
        return _entities.FirstOrDefault(el => el.Id == id);
    }
}