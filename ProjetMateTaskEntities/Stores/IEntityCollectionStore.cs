using System.Collections.Specialized;
using System.ComponentModel;
using ProjetMateTaskEntities.Entities.Base;

namespace ProjetMateTaskEntities.Stores;

/// <summary>
///     Коллекцию работающая с Entity
/// </summary>
/// <typeparam name="T">Любой Entity тип</typeparam>
public interface IEntityCollectionStore<T>: ICollection<T>, INotifyCollectionChanged, INotifyPropertyChanged where T:IEntity
{
    public bool Contains(int id);

    public T Find(int id);
    
}