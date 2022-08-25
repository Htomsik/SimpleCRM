using System;
using ProjectMateTask.Infrastructure.CMD.Base;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.NavigationServices;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.TypeNavigationServices;

namespace ProjectMateTask.Infrastructure.CMD.AppInfrastructure;

internal sealed class TypeNavigationCmd: BaseCmd
{
    
    private readonly ITypeNavigationServices _typeNavigationServices;
    
    private readonly Predicate<object> _canExecute;

    public TypeNavigationCmd(ITypeNavigationServices typeNavigationServices,Predicate<object> canExecute)
    {
        _canExecute = canExecute;
        
        _typeNavigationServices = typeNavigationServices;
    }
    
    
    public TypeNavigationCmd(ITypeNavigationServices navigationService,Func<bool> canExecute = null)
        :this(navigationService,canExecute is null ? null : p => canExecute()){}


    protected override void Execute(object? parameter) => _typeNavigationServices.Navigate((Type)parameter);

}