using System;
using System.Windows.Input;

namespace ProjectMateTask.Infrastructure.CMD.Base;

/// <summary>
///  Базовая реализация для команд
/// </summary>
public abstract class BaseCmd:ICommand
{
    bool ICommand.CanExecute(object? parameter) => _executable && CanExecute(parameter);

    void ICommand.Execute(object? parameter)
    {
        if(CanExecute(parameter))
            Execute(parameter);
    }

    /// <summary>
    /// Условие выполнения
    /// </summary>
    /// <param name="parameter">Параметр для условия</param>
    protected virtual bool CanExecute(object? parameter) => true;

    /// <summary>
    /// Выполняемое действие
    /// </summary>
    /// <param name="parameter"></param>
    protected abstract void Execute(object parameter);
    
    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested += value;
    }
    
    private bool _executable =true;

    /// <summary>
    /// Флаг, может ли команда выполняться.
    /// default: true
    /// </summary>
    public bool Executable
    {
        get => _executable;
        set
        {
            if(_executable == value) return;
            _executable = value;
            CommandManager.InvalidateRequerySuggested();
        }
    }
}