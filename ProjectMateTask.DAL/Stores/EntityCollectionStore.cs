using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore.Query.Internal;
using ProjectMateTask.DAL.Entities.Base;

namespace ProjectMateTask.DAL.Stores;

public class EntityCollectionStore<TEntity>:ObservableCollection<TEntity>,IEntityCollectionStore<TEntity> where TEntity:IEntity
{
    public EntityCollectionStore(){}
    public EntityCollectionStore(IEnumerable<TEntity> collection) : base(collection){}
    
    public EntityCollectionStore(List<TEntity> list) : base(list){}
    
    public EntityCollectionStore(TEntity[] entities) : base(entities){}
    
    public bool Equals(object? other)
    {
        if (other == null)
            return false;

        if (ReferenceEquals(this, other))
            return true;

        if (GetType() != other.GetType())
            return false;

        return Equals(other as ICollection<TEntity>);
    }

    protected virtual bool Equals(ICollection<TEntity> other)
    {
        if (Items.Count != other.Count) return false;

        if (Items.Count == 0 && other.Count == 0) return true;

        //Проверка есть ли в коллекции А Id из коллекций B. Подсчет количества разных Id
        return Items.Count(item => other.All(subItem => subItem.Id != item.Id)) == 0;
    }

    public IEnumerator<TEntity> GetEnumerator() => base.GetEnumerator();
    
    public void Add(TEntity item)
    {
        if (Contains(item.Id)) return;
        
            // throw new ArgumentException($"Элемент {nameof(item)} уже присутсвует в {nameof(this.GetType)}");
        
        base.Add(item);
    }

    public bool Contains(TEntity item) => Contains(item.Id);
    
    public bool Contains(int id) => Find(id) is not null;

    public TEntity Find(int id) => Items.FirstOrDefault(item => item.Id == id);
   
    
    public void CopyTo(TEntity[] array, int arrayIndex) => base.CopyTo(array,arrayIndex);


    public bool Remove(TEntity item) => base.Remove(item);
   
    public bool IsReadOnly { get; }

    public bool IsDbCollection { get; }
}