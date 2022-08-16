using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using ProjectMateTask.DAL.Entities.Base;

namespace ProjectMateTask.DAL.Stores;

public interface IEntityCollectionStore<T>: ICollection<T>, INotifyCollectionChanged, INotifyPropertyChanged where T:IEntity
{
    public bool Contains(int id);

    public T Find(int id);
    
}