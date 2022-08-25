using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Threading;

namespace ProjectMateTask.VMD.Base;

/// <summary>
///     Базовая реализация INPC
/// </summary>
public abstract class BaseVmd:INotifyPropertyChanged, IDisposable
{
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    ///     Метод обноавления свойтсва
    /// </summary>
    /// <param name="propertyName">Имя вызывающего обьекта</param>
    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        var handlers = PropertyChanged;

        if (handlers is null) return;

        var invocationList = handlers.GetInvocationList();

        var arg = new PropertyChangedEventArgs(propertyName);

        foreach (var action in invocationList)
            if (action.Target is DispatcherObject dispObject)
                dispObject.Dispatcher.Invoke(action, this, arg);
            else
                action.DynamicInvoke(this, arg);
    }
  
    /// <summary>
    ///     Метод обновления данных
    /// </summary>
    /// <param name="field">Сслыка на обновляемое поле</param>
    /// <param name="value">Значние задаваемое для поля</param>
    /// <param name="propertyName">Имя вызывающего значения</param>
    /// <typeparam name="T">Любой тип</typeparam>
    /// <returns></returns>
    protected bool Set<T>(ref T field, T value,[CallerMemberName] string? propertyName = null)
    {
        if (Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
    
    /// <summary>
    ///     Метод для деструктоа
    /// </summary>
    public virtual void Dispose() {}

   
}