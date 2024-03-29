﻿using System;
using SimpleSRM.WPF.Infrastructure.CMD.Base;
using SimpleSRM.WPF.Services.AppInfrastructure.NavigationServices.Base.CloseNavigationServices;

namespace SimpleSRM.WPF.Infrastructure.CMD.AppInfrastructure;

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
        _closeNavigationServices =  closeNavigationServices is null
                ? throw new ArgumentNullException(nameof(_closeNavigationServices)) :
            new Lazy<ICloseNavigationServices>(()=>closeNavigationServices);

        _canExecute = new Lazy<Predicate<object>>(()=>canExecute);
    }

    /// <summary>
    ///  Контруктор для условий выполнения только с выходным параметром
    /// </summary>
    /// <param name="closeNavigationServices">Сервис закрытия</param>
    /// <param name="canExecute">Условие выполнения команды</param>
    /// <exception cref="ArgumentNullException">Возникает в случае если _closeNavigationServices null</exception>
    public CloseNavigationCmd(ICloseNavigationServices closeNavigationServices, Func<bool> canExecute = null)
        : this(
            closeNavigationServices ??
            throw new ArgumentNullException(nameof(_closeNavigationServices))
            , canExecute is null ? null : p => canExecute())
    {
    }
    
    /// <summary>
    ///  Контруктор без условия выполнения
    /// </summary>
    /// <param name="closeNavigationServices">Сервис закрытия</param>
    /// <exception cref="ArgumentNullException">Возникает в случае если _closeNavigationServices null</exception>
    public CloseNavigationCmd(ICloseNavigationServices closeNavigationServices) 
        : this(closeNavigationServices 
               ?? throw new ArgumentNullException(nameof(_closeNavigationServices)),
        p => true)
    {
    }

    protected override void Execute(object? parameter) => _closeNavigationServices.Value.Close();


    protected override bool CanExecute(object parameter) => _canExecute.Value(parameter);

}