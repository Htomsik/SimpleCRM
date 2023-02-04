using System;
using SimpleSRM.WPF.Infrastructure.CMD.Base;
using SimpleSRM.WPF.Services.AppInfrastructure.NavigationServices.Base.NavigationServices;

namespace SimpleSRM.WPF.Infrastructure.CMD.AppInfrastructure;

/// <summary>
///     Навигационная команда через навигационные сервисы
/// </summary>
internal sealed class NavigationCmd : BaseCmd
{
    private readonly Lazy<Predicate<object>> _canExecute;
    
    private readonly Lazy<INavigationService> _navigationService;

    /// <summary>
    ///     Контруктор для условий выполнения с входным и выходным параметром
    /// </summary>
    /// <param name="navigationService">Сервис взаимодействующий с хранилищем текущего контекстаа</param>
    /// <param name="canExecute">Условие при котором команда выполняется</param>
    /// <exception cref="ArgumentNullException">Возникает в случае если navigationService null </exception>
    public NavigationCmd(INavigationService navigationService, Predicate<object> canExecute = null)
    {
        _navigationService = navigationService is null 
            ? throw new ArgumentNullException(nameof(_navigationService)) :
            new Lazy<INavigationService>(() => navigationService);

        _canExecute = new Lazy<Predicate<object>>(() => canExecute);
    }

    /// <summary>
    ///     Контруктор для условий выполнения только с выходным параметром
    /// </summary>
    /// <param name="navigationService">Сервис взаимодействующий с хранилищем текущего контекстаа</param>
    /// <param name="canExecute">Условие при котором команда выполняется</param>
    /// <exception cref="ArgumentNullException">Возникает в случае если navigationService null </exception>
    public NavigationCmd(INavigationService navigationService, Func<bool> canExecute = null)
        : this(navigationService ?? throw new ArgumentNullException(nameof(_navigationService)), canExecute is null ? null : p => canExecute())
    {
    }
    
    /// <summary>
    ///     Контруктор без условий выполнения 
    /// </summary>
    /// <param name="navigationService">Сервис взаимодействующий с хранилищем текущего контекстаа</param>
    /// <exception cref="ArgumentNullException">Возникает в случае если navigationService null </exception>
    public NavigationCmd(INavigationService navigationService) : this(navigationService  ?? throw new ArgumentNullException(nameof(_navigationService)) ,()=> true){}


    protected override void Execute(object? parameter) =>  _navigationService.Value.Navigate();

    protected override bool CanExecute(object parameter) =>_canExecute.Value(parameter);
    
}