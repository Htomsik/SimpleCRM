using System.ComponentModel;
using System.Windows.Input;

namespace SimpleSRM.WPF.VMD.Pages.AdditionalPagesVmds.Base;

/// <summary>
///     Vmd тип для доп окон
/// </summary>
internal interface IAdditionalVmd : INotifyPropertyChanged
{
    /// <summary>
    ///     Команда закрытия доп окна
    /// </summary>
    public ICommand CloseAdditionalCommand { get; }
}