using System;
using ProjectMateTask.Infrastructure.CMD.Base;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.CloseNavigationServices;

namespace ProjectMateTask.Infrastructure.CMD.AppInfrastructure;

/// <summary>
///     Навигационная команда для закрытия
/// </summary>
internal sealed class CloseNavigationCmd : BaseCmd
{
    private readonly Lazy<Predicate<object>>  _canExecute;
    private readonly Lazy<ICloseNavigationServices>  _closeNavigationServices;

    /// <summary>
    ///  Контруктор для условий выполнения с входным и выходным параметром
    /// </summary>
    /// <param name="closeNavigationServices">Сервис закрытия</param>
    /// <param name="canExecute">Условие выполнения команды</param>
    /// <exception cref="ArgumentNullException">Возникает в случае если _closeNavigationServices null</exception>
    public CloseNavigationCmd(ICloseNavigationServices closeNavigationServices, Predicate<object> canExecute = null)
    {
        _closeNavigationServices = 
            new Lazy<ICloseNavigationServices>(()=>closeNavigationServices)
            ?? throw new ArgumentNullException(nameof(_closeNavigationServices));

        _canExecute = new Lazy<Predicate<object>>(()=>canExecute);
    }

    /// <summary>
    ///  Контруктор для условий выполнения только с выходным параметром
    /// </summary>
    /// <param name="closeNavigationServices">Сервис закрытия</param>
    /// <param name="canExecute">Условие выполнения команды</param>
    /// <exception cref="ArgumentNullException">Возникает в случае если _closeNavigationServices null</exception>
    public CloseNavigationCmd(ICloseNavigationServices closeNavigationServices, Func<bool> canExecute = null)
        : this(closeNavigationServices, canExecute is null ? null : p => canExecute())
    {
    }
    
    /// <summary>
    ///  Контруктор без условия выполнения
    /// </summary>
    /// <param name="closeNavigationServices">Сервис закрытия</param>
    /// <exception cref="ArgumentNullException">Возникает в случае если _closeNavigationServices null</exception>
    public CloseNavigationCmd(ICloseNavigationServices closeNavigationServices) : this(closeNavigationServices,
        p => true)
    {
    }

    protected override void Execute(object? parameter) => _closeNavigationServices.Value.Close();


    protected override bool CanExecute(object parameter) => _canExecute.Value(parameter);

}