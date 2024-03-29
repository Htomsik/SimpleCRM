﻿using System;
using SimpleSRM.WPF.Infrastructure.CMD.Base;
using SimpleSRM.WPF.Services.AppInfrastructure.NavigationServices.Base.TypeNavigationServices;

namespace SimpleSRM.WPF.Infrastructure.CMD.AppInfrastructure;

/// <summary>
///     Команда навигации по типам зарегистировнным в IOC контейнере
/// </summary>
internal sealed class TypeNavigationCmd : BaseCmd
{
    private readonly Lazy<Predicate<object>> _canExecute;

    private readonly Lazy<ITypeNavigationServices> _typeNavigationServices;

    /// <summary>
    ///     Контруктор для условий выполнения с входным и выходным параметром
    /// </summary>
    /// <param name="typeNavigationServices">Сервис навигации по типу</param>
    /// <param name="canExecute">Условие выполнения команды</param>
    /// <exception cref="ArgumentNullException">Возникает в случае если typeNavigationServices null</exception>
    public TypeNavigationCmd(ITypeNavigationServices typeNavigationServices, Predicate<object> canExecute = null)
    {
        _canExecute = new Lazy<Predicate<object>>(() => canExecute);

        _typeNavigationServices = typeNavigationServices is null
                ? throw new ArgumentNullException(nameof(_typeNavigationServices))
                : new Lazy<ITypeNavigationServices>(() => typeNavigationServices);
    }

    /// <summary>
    ///     Контруктор для условий выполнения только с выходным параметром
    /// </summary>
    /// <param name="typeNavigationServices">Сервис навигации по типу</param>
    /// <param name="canExecute">Условие выполнения команды</param>
    /// <exception cref="ArgumentNullException">Возникает в случае если typeNavigationServices null </exception>
    public TypeNavigationCmd(ITypeNavigationServices typeNavigationServices, Func<bool> canExecute = null)
        : this(typeNavigationServices ?? throw new ArgumentNullException(nameof(_typeNavigationServices)), canExecute is null ? null : p => canExecute())
    {
    }


    /// <summary>
    ///     Конструктор без условий выполнения
    /// </summary>
    /// <param name="typeNavigationServices">Сервис навигации по типу</param>
    /// <exception cref="ArgumentNullException">Возникает в случае если typeNavigationServices null </exception>
    public TypeNavigationCmd(ITypeNavigationServices typeNavigationServices) : this(typeNavigationServices ?? throw new ArgumentNullException(nameof(_typeNavigationServices)), () => true)
    {
        
    }

    protected override void Execute(object? parameter) =>_typeNavigationServices.Value.Navigate((Type)parameter);
  

    protected override bool CanExecute(object? parameter) =>  _canExecute.Value(parameter);
   
}