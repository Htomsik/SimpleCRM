using System;

namespace ProjectMateTask.Stores.Base;

internal interface IStore<TValue> 
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