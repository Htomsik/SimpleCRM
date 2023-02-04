using System;

namespace ProjectMateTask.Stores.Base;

/// <summary>
///     Бзовая реализация хранилища
/// </summary>
/// <typeparam name="T">Любой класс</typeparam>
public class BaseStore<T> : IStore<T> where T : class
{
    protected Lazy<T?> _currentValue;

    public virtual T? CurrentValue
    {
        get => _currentValue?.Value;
        set
        {
            _currentValue = new Lazy<T>(() => value);
            OnCurrentValueChanged();
        }
    }

    public event Action? CurrentValueChanged;

    /// <summary>
    ///     Метод, обновляющий увидомитель
    /// </summary>
    protected virtual void OnCurrentValueChanged() =>CurrentValueChanged?.Invoke();
  
}