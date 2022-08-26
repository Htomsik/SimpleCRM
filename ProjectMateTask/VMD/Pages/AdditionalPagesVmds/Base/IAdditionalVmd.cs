using System.ComponentModel;
using System.Windows.Input;

namespace ProjectMateTask.VMD.Pages.AdditionalPagesVmds.Base;

internal interface IAdditionalVmd : INotifyPropertyChanged
{
    public ICommand CloseAdditionalCommand { get; }
}