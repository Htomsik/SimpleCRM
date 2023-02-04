namespace SimpleSRM.WPF.Services.AppInfrastructure.UserDialogServices.Base;

/// <summary>
///     Модальное окно
/// </summary>
public interface IUserDialogService
{
    /// <summary>
    ///     Показ информационного окна
    /// </summary>
    /// <param name="information">Отобажаемая информация</param>
    /// <param name="caption">Название окна</param>
    /// <returns></returns>
    bool ConfirmInformation(string information, string caption);

    /// <summary>
    ///     Показ предупеждающего окна
    /// </summary>
    /// <param name="warning">Отображаемое предупреждение</param>
    /// <param name="caption">Название окна</param>
    /// <returns></returns>
    bool ConfirmWarning(string warning, string caption);

    /// <summary>
    ///     Показ окна об ошибке
    /// </summary>
    /// <param name="error">Отображаемая ошибка</param>
    /// <param name="caption">Название окна</param>
    /// <returns></returns>
    bool ConfirmError(string error, string caption);

    /// <summary>
    ///     Показ окна с критической ошибкой
    /// </summary>
    /// <param name="criticalError">Отображаемая критическая ошибка</param>
    /// <param name="caption">Название окна</param>
    /// <returns></returns>
    bool ConfirmCriticalError(string criticalError, string caption);
}