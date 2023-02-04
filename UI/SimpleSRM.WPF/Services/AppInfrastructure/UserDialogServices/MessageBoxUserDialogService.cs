using System.Windows;
using SimpleSRM.WPF.Services.AppInfrastructure.UserDialogServices.Base;

namespace SimpleSRM.WPF.Services.AppInfrastructure.UserDialogServices;

/// <summary>
///    Сервис показа модального messageBox окна 
/// </summary>
public class MessageBoxUserDialogService : IUserDialogService
{
    public bool ConfirmInformation(string information, string caption) =>
        MessageBox
            .Show(
                information, caption, 
                MessageBoxButton.YesNo, 
                MessageBoxImage.Information)
        == MessageBoxResult.Yes;
   

    public bool ConfirmWarning(string warning, string caption) =>
        MessageBox
            .Show(
                warning, caption, 
                MessageBoxButton.YesNo, 
                MessageBoxImage.Warning)
        == MessageBoxResult.Yes;
    
    public bool ConfirmError(string error, string caption) =>
        MessageBox
            .Show(
                error, caption, 
                MessageBoxButton.YesNo, 
                MessageBoxImage.Error)
        == MessageBoxResult.Yes;

    public bool ConfirmCriticalError(string criticalError, string caption) =>
        MessageBox
            .Show(
                criticalError, caption, 
                MessageBoxButton.OK, 
                MessageBoxImage.Error)
        == MessageBoxResult.OK;
}