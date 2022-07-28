using System.Windows.Input;
using ProjectMateTask.Models.AppInfrastructure.Enums;
using ProjectMateTask.Stores.AppInfrastructure;
using ProjectMateTask.VMD.Base;

namespace ProjectMateTask.VMD.AppInfrastructure;

public class DialogWindowVmd:BaseVmd
{
    
    public BaseVmd CurrentDialogVmd { get; }
    
    public DialogWindowType DialogType { get; }
    
    public ICommand AcceptDialogCommand { get; }

    private bool IsAccepted;

    

    private bool CanAcceptDialogCommandExecuted() => IsAccepted;
    
    public ICommand CancelDialogCommand { get; }

    public DialogWindowVmd()
    {
        
    }
}