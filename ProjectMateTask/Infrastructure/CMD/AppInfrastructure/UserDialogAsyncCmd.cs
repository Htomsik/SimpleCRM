using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ProjectMateTask.Services.AppInfrastructure.UserDialogServices.Base;

namespace ProjectMateTask.Infrastructure.CMD.AppInfrastructure;

/// <summary>
///    Асинхронная команда, выполняемая после подтверждения через IUserDialogService
/// </summary>
internal sealed class UserDialogAsyncCmd : AsyncLambdaCmd
{
    
    private readonly Lazy<string>  _warning;
    
    private Lazy<IUserDialogService>  _userDialogService;
    
    /// <summary>
    ///     Контруктор для условий с входным и выходным параметром
    /// </summary>
    /// <param name="execute">Выполняемое действие</param>
    /// <param name="warning">Отображаемое предупреждение</param>
    /// <param name="canExecute">Условие выполнения</param>
    /// <exception cref="ArgumentNullException">В случае если execute или warning null</exception>
    public UserDialogAsyncCmd(Func<object, Task> execute,string warning, Func<object, bool> canExecute = null) : base(execute, canExecute)
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
    public UserDialogAsyncCmd(Func<Task> execute,string warning, Func<bool> canExecute = null) : base(execute, canExecute)
    {
        _warning = new Lazy<string>(()=>warning) ?? throw new ArgumentNullException(nameof(_warning));
        _userDialogService = new Lazy<IUserDialogService>(()=>App.Services.GetRequiredService<IUserDialogService>());
    }

    protected override void Execute(object? parameter)
    {
        if (_userDialogService.Value.ConfirmWarning(_warning.Value, "Предупреждение"))
            base.Execute(parameter);
    }
}