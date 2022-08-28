using System.Collections.Specialized;
using System.ComponentModel;
using ProjetMateTaskEntities.Entities.Base;

namespace ProjetMateTaskEntities.Stores;

public interface IEntityCollectionStore<T>: ICollection<T>, INotifyCollectionChanged, INotifyPropertyChanged where T:IEntity
{
    public bool Contains(int id);

    public T Find(int id);
    
}