using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ProjectMateTask.Stores.Base;

public interface IReadOnlyCollectionStore<T>
{
    public  IReadOnlyCollection<T> CurrentItems { get; }

    public event Action CurrentItemChanged;

    public void Remove(T item);

    public void Add(T item);
}