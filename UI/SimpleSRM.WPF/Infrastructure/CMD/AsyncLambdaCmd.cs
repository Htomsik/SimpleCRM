﻿using System;
using System.Threading.Tasks;
using System.Windows.Input;
using SimpleSRM.WPF.Infrastructure.CMD.Base;

namespace SimpleSRM.WPF.Infrastructure.CMD;

/// <summary>
/// Асинхронная команда с условием выполнения
/// </summary>
public class AsyncLambdaCmd : BaseCmd
{
    private readonly Lazy<Func<object, bool>>  _canExecute;

    private readonly Lazy<Func<object, Task>>  _execute;
    
    /// <summary>
    /// Контруктор для условий с входным и выходным параметром
    /// </summary>
    /// <param name="execute">Выполняемое действие</param>
    /// <param name="canExecute">Условие выполнения</param>
    /// <exception cref="ArgumentNullException">В случае если execute null</exception>
    public AsyncLambdaCmd(Func<object, Task> execute,
        Func<object, bool> canExecute = null)
    {
        _execute = execute is null 
            ? throw new ArgumentNullException(nameof(execute)) 
            : new Lazy<Func<object, Task>>(()=>execute);
        
        _canExecute = new Lazy<Func<object, bool>>(()=>canExecute);
    }
    
    /// <summary>
    /// Контруктор для условий только с выходным параметром
    /// </summary>
    /// <param name="execute">Выполняемое действие</param>
    /// <param name="canExecute">Условие выполнения</param>
    /// <exception cref="ArgumentNullException">В случае если execute null</exception>
    public AsyncLambdaCmd(Func<Task> execute,
        Func<bool> canExecute = null)
        :this(execute is null 
            ? throw new ArgumentNullException(nameof(execute))  
            :  _ => execute()
            , canExecute is null 
                ? null 
                : _ => canExecute()){}
    
    
    protected override bool CanExecute(object? parameter)
    {
        if (!IsExecuting)
            return _canExecute?.Value?.Invoke(parameter!) ?? true;
        return false;
    }

    protected override async void Execute(object? parameter)
    {
        IsExecuting = true;

        try
        {
            await ExecuteAsync(parameter);
        }
        catch (Exception )
        {
            
        }

        IsExecuting = false;

        CommandManager.InvalidateRequerySuggested();
    }

    /// <summary>
    /// Асинхронное выполнение команды
    /// </summary>
    /// <param name="parameter">Параметр для команды</param>
    private async Task ExecuteAsync(object parameter) =>await _execute.Value(parameter);

    #region IsExecuting : флаг того что команда выполняется в данный момент

    private bool _isExecuting ;

    /// <summary>
    /// флаг того что команда выполняется в данный момент
    /// </summary>
    public bool IsExecuting
    {
        get => _isExecuting;
        set
        {
            if(_isExecuting == value) return;
            _isExecuting = value;
            CommandManager.InvalidateRequerySuggested();
        }
    }

    #endregion
    
}
