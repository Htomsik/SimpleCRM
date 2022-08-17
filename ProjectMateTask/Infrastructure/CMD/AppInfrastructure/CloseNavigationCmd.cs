using System;
using ProjectMateTask.Infrastructure.CMD.Base;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base;

namespace ProjectMateTask.Infrastructure.CMD.AppInfrastructure;

internal sealed class CloseNavigationCmd:BaseCmd
{
    private readonly ICloseNavigationServices _closeNavigationServices;
    
    private readonly Predicate<object> _canExecute;
    
    public CloseNavigationCmd(ICloseNavigationServices closeNavigationServices,Predicate<object> canExecute = null)
    {
        _closeNavigationServices = closeNavigationServices;
        
        _canExecute = canExecute;
    }
    
    public CloseNavigationCmd(ICloseNavigationServices closeNavigationServices,Func<bool> canExecute = null)
        :this(closeNavigationServices,canExecute is null ? null : p => canExecute()){}

    public CloseNavigationCmd(ICloseNavigationServices closeNavigationServices) : this(closeNavigationServices,
        p=> true){}
    
    protected override void Execute(object? parameter) => _closeNavigationServices.Close();
    protected override bool CanExecute(object parameter) => _canExecute(parameter);
}