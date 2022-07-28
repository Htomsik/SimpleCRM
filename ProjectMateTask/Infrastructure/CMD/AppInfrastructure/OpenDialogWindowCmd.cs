using System;
using System.Windows;
using ProjectMateTask.Infrastructure.CMD.Base;
using ProjectMateTask.VMD.AppInfrastructure;
using ProjectMateTask.VW.Windows;

namespace ProjectMateTask.Infrastructure.CMD.AppInfrastructure;

public class OpenDialogWindowCmd:BaseCmd
{
    private DialogWindow? _dialogWindow;
    protected override void Execute(object? parameter)
    {
        var newdialogWindow = new DialogWindow
        {
            Owner = Application.Current.MainWindow
        };

        newdialogWindow.DataContext = new DialogWindowVmd();
        
        _dialogWindow = newdialogWindow;

        _dialogWindow.Closed += OnDialogWindowClosed;
        
        _dialogWindow.ShowDialog();
    }

    private void OnDialogWindowClosed(object? sender, EventArgs e)
    {
        ((Window)sender!).Closed -= OnDialogWindowClosed;
        _dialogWindow = null;
    }

    protected override bool CanExecute(object? parameter) => _dialogWindow == null;

}