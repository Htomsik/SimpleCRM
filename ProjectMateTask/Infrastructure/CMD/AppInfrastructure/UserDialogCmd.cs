using System;
using Microsoft.Extensions.DependencyInjection;
using ProjectMateTask.Services.AppInfrastructure.UserDialogServices.Base;

namespace ProjectMateTask.Infrastructure.CMD.AppInfrastructure;

/// <summary>
///     Команда, выполняемая после подтверждения через IUserDialogService
/// </summary>
internal sealed class UserDialogCmd : LambdaCmd   
{
    private readonly Lazy<string>  _warning;
    
    private Lazy<IUserDialogService>  _userDialogService;
    
    protected override void Execute(object parameter)
    {
        if (_userDialogService.Value.ConfirmWarning(_warning.Value, "Предупреждение"))
            base.Execute(parameter);
    }
  

    /// <summary>
    ///     Контруктор для условий с входным и выходным параметром
    /// </summary>
    /// <param name="execute">Выполняемое действие</param>
    /// <param name="warning">Отображаемое предупреждение</param>
    /// <param name="canExecute">Условие выполнения</param>
    /// <exception cref="ArgumentNullException">В случае если execute или warning null</exception>
    public UserDialogCmd(Action<object> execute,string warning, Func<object, bool> canExecute = null) : base(execute, canExecute) 
    {
        _warning = new Lazy<string>(()=>warning) ?? throw new ArgumentNullException(nameof(_warning));
        _userDialogService = new Lazy<IUserDialogService>(()=>App.Services.GetRequiredService<IUserDialogService>());
    }

    /// <summary>
    ///     Контруктор для условий только с выходным параметром
    /// </summary>
    /// <param name="execute">Выполняемое действие</param>
    /// <param name="warning">Отображаемое предупреждение</param>
    /// <param name="canExecute">Условие выполнения</param>
    /// <exception cref="ArgumentNullException">В случае если execute или warning null</exception>
    public UserDialogCmd(Action execute,string warning, Func<bool> canExecute = null) : base(execute, canExecute)
    {
        _warning = new Lazy<string>(()=>warning) ?? throw new ArgumentNullException(nameof(_warning));
        _userDialogService = new Lazy<IUserDialogService>(()=>App.Services.GetRequiredService<IUserDialogService>());
    }
}