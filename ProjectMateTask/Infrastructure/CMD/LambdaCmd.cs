using System;
using ProjectMateTask.Infrastructure.CMD.Base;

namespace ProjectMateTask.Infrastructure.CMD;

/// <summary>
/// Команда с условием выполнения
/// </summary>
public sealed class LambdaCmd : BaseCmd
{
    private readonly Lazy<Func<object, bool>>  _canExecute;
    
    private readonly Lazy<Action<object>>  _execute;
    
    /// <summary>
    /// Контруктор для условий с входным и выходным параметром
    /// </summary>
    /// <param name="execute">Выполняемое действие</param>
    /// <param name="canExecute">Условие выполнения</param>
    /// <exception cref="ArgumentNullException">В случае если execute null</exception>
    public LambdaCmd(Action<object> execute, Func<object, bool> canExecute = null)
    {
        _execute = new Lazy<Action<object>>(()=>execute) ?? throw new ArgumentNullException(nameof(execute));

        _canExecute = new Lazy<Func<object, bool>>(()=>canExecute);
    }

    /// <summary>
    /// Контруктор для условий только с выходным параметром
    /// </summary>
    /// <param name="execute"></param>
    /// <param name="canExecute"></param>
    /// <exception cref="ArgumentNullException">В случае если execute null</exception>
    public LambdaCmd(Action execute, Func<bool> canExecute = null)
        : this(p => execute(), canExecute is null ? null : p => canExecute()){}
    

    protected override bool CanExecute(object parameter) => _canExecute?.Value?.Invoke(parameter) ?? true;

    protected override void Execute(object parameter) => _execute.Value(parameter);
   
}