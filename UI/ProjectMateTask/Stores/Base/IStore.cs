using System;

namespace ProjectMateTask.Stores.Base;

/// <summary>
///     Хранилише
/// </summary>
/// <typeparam name="TValue">Любой тип</typeparam>
public interface IStore<TValue> 
{
    /// <summary>
    ///     Текущее значение хранилища
    /// </summary>
    public TValue? CurrentValue { get; set; }

    /// <summary>
    ///     Уведомитель об изменении
    /// </summary>
    public event Action CurrentValueChanged;
}