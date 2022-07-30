using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using ProjectMateTask.Infrastructure.CMD.Base;

namespace ProjectMateTask.Infrastructure.CMD;

internal sealed class AsyncLambdaCmd : BaseCmd
{
    private readonly Func<object, bool> _canExecute;

    private readonly Func<object, Task> _execute;
    
    public AsyncLambdaCmd(Func<object, Task> execute,
        Func<object, bool> canExecute = null)
    {
        _execute = execute;
        _canExecute = canExecute;
    }
    
    public AsyncLambdaCmd(Func<Task> execute,
        Func<bool> canExecute = null)
        :this(p => execute(), canExecute is null ? null : p => canExecute()){}
    
    
    protected override bool CanExecute(object? parameter)
    {
        if (!IsExecuting)
            return _canExecute?.Invoke(parameter!) ?? true;
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

    private async Task ExecuteAsync(object parameter)
    {
        await _execute(parameter);
    }
    
    private bool _isExecuting ;

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
}
