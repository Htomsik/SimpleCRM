using System;
using ProjectMateTask.Infrastructure.CMD.Base;

namespace ProjectMateTask.Infrastructure.CMD;

public class LambdaCmd : BaseCmd
{
    private readonly Func<object, bool> _canExecute;
    
    private readonly Action<object> _execute;
    
    public LambdaCmd(Action<object> execute, Func<object, bool> canExecute = null)
    {
        _execute = execute ?? throw new ArgumentNullException(nameof(execute));

        _canExecute = canExecute;
    }

    public LambdaCmd(Action execute, Func<bool> canExecute = null)
        : this(p => execute(), canExecute is null ? null : p => canExecute()){}
   

    protected override bool CanExecute(object parameter) => _canExecute(parameter!);

    protected override void Execute(object parameter) => _execute(parameter);
   
}