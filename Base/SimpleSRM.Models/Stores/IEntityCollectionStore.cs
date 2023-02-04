using System.Collections.Specialized;
using System.ComponentModel;
using SimpleSRM.Models.Entities.Base;

namespace SimpleSRM.Models.Stores;

/// <summary>
///     Коллекцию работающая с Entity
/// </summary>
/// <typeparam name="T">Любой Entity тип</typeparam>
public interface IEntityCollectionStore<T>: ICollection<T>, INotifyCollectionChanged, INotifyPropertyChanged where T:IEntity
{
    public bool Contains(int id);

    public T Find(int id);
    
}