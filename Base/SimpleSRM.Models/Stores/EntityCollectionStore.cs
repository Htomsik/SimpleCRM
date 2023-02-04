using System.Collections.ObjectModel;
using SimpleSRM.Models.Entities.Base;
using SimpleSRM.Models.Services;

namespace SimpleSRM.Models.Stores;

/// <summary>
///     Реализация коллекци Entity (особенность в проверке  перед добавление в коллекцию. Не позволяет содержать id дубликаты)
/// </summary>
/// <typeparam name="TEntity">Любой Entity тип</typeparam>
public class EntityCollectionStore<TEntity>:ObservableCollection<TEntity>,IEntityCollectionStore<TEntity> where TEntity:IEntity
{
    #region Конструкторы

    public EntityCollectionStore(){}

    public EntityCollectionStore(IEnumerable<TEntity> collection) : base(collection)
    {
        if (EntityCollectionServices.IsCollectionHaveDuplicateByIds(collection))
            throw new ArgumentException($"Коллекция c {typeof(TEntity)} не может содержать id дубликаты");
        
     
    }

    public EntityCollectionStore(List<TEntity> list) : base(list)
    {
        if (EntityCollectionServices.IsCollectionHaveDuplicateByIds(list))
            throw new ArgumentException($"Коллекция c {typeof(TEntity)} не может содержать id дубликаты");
    }

    public EntityCollectionStore(TEntity[] entities) : base(entities)
    {
        if (EntityCollectionServices.IsCollectionHaveDuplicateByIds(entities))
            throw new ArgumentException($"Коллекция c {typeof(TEntity)} не может содержать id дубликаты");
    }

    #endregion

    #region Методы

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

    /// <summary>
    ///     Метод сравнения для наследников
    /// </summary>
    /// <param name="other">Сравниваемая коллекция</param>
    /// <returns></returns>
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
        
        base.Add(item);
    }

    public bool Contains(TEntity item) => Find(item.Id).Equals(item);
    
    /// <summary>
    ///     Поиск в коллекции Entity по id
    /// </summary>
    /// <param name="id">Идентификатор Entity в бд</param>
    /// <returns>True - если существует</returns>
    public bool Contains(int id) => Find(id) is not null;

    /// <summary>
    ///     Поиск в коллекции Entity по id
    /// </summary>
    /// <param name="id">Идентификатор Entity в бд</param>
    /// <returns>Entity если ссущесвтует, в противном случае Default</returns>
    public TEntity Find(int id) => Items.FirstOrDefault(item => item.Id == id);
    
    public void CopyTo(TEntity[] array, int arrayIndex) => base.CopyTo(array,arrayIndex);
    
    public bool Remove(TEntity item) => base.Remove(item);

    public bool IsReadOnly => false;

    #endregion
    
}