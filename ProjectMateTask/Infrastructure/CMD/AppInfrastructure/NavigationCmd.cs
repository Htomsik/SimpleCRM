﻿using System;
using ProjectMateTask.Infrastructure.CMD.Base;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.NavigationServices;

namespace ProjectMateTask.Infrastructure.CMD.AppInfrastructure;

internal sealed class NavigationCmd:BaseCmd
{
    private readonly INavigationService _navigationService;
    
    private readonly Predicate<object> _canExecute;

    /// <summary>
    /// Команды смены ViewModel
    /// </summary>
    /// <param name="navigationService">Сервис взаимодействующий с хранилищем текущего контекстаа</param>
    /// <param name="canExecute">Параметр при котором команда выполняется</param>
    public NavigationCmd(INavigationService navigationService,Predicate<object> canExecute = null)
    {
        _navigationService = navigationService;
        
        _canExecute = canExecute;
    }
    
    public NavigationCmd(INavigationService navigationService,Func<bool> canExecute = null)
        :this(navigationService,canExecute is null ? null : p => canExecute()){}

   

    protected override void Execute(object? parameter) => _navigationService.Navigate();
    protected override bool CanExecute(object parameter) => _canExecute(parameter);
}