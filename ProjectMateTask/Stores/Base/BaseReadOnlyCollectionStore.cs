using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ProjectMateTask.DAL.Entities.Actors;
using ProjectMateTask.DAL.Entities.Base;

namespace ProjectMateTask.Stores.Base;

internal abstract class BaseReadOnlyCollectionStore<T> : IReadOnlyCollectionStore<T> where T : INamedEntity
{
    private ICollection<T> _currentItems;
    public IReadOnlyCollection<T> CurrentItems => (new ReadOnlyObservableCollection<T>(new ObservableCollection<T>(_currentItems)));
    
    public event Action? CurrentItemChanged;
    
    
    void IReadOnlyCollectionStore<T>.Remove(T item)
    {
        Remove(item);
        OnCurrentItemChanged();
    }

    void IReadOnlyCollectionStore<T>.Add(T item)
    {
        Add(item);
        OnCurrentItemChanged();
    }
    
    
    protected virtual void Remove(T item)
    {
        var findItem = CurrentItems.FirstOrDefault(item);

        if (findItem is null)
            throw new ArgumentException($"Элемент {nameof(item)} отсутсвует в {nameof(this.GetType)}");
        
        _currentItems.Remove(item);
    }

    public virtual void Add(T item)
    {
        T findItem = _currentItems.FirstOrDefault(el => el.Equals(item),default);

        if (findItem is not null)
            throw new ArgumentException($"Элемент {nameof(item)} уже присутсвует в {nameof(this.GetType)}");
        
        _currentItems.Add(item);
    }

    private void OnCurrentItemChanged()
    {
        CurrentItemChanged?.Invoke();
    }
}