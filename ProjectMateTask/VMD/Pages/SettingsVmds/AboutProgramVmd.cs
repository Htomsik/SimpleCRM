using System.Windows.Input;
using ProjectMateTask.Infrastructure.CMD.AppInfrastructure;
using ProjectMateTask.VMD.Base;

namespace ProjectMateTask.VMD.Pages.SettingsVmds;

internal sealed class AboutProgramVmd : BaseVmd
{
    public string AppVersion { get; } = "0.0.1";

    public ICommand OpenGithubCommand { get; }
    public AboutProgramVmd()
    {
        OpenGithubCommand = new OpenBrowserLinkCmd("https://github.com/Htomsik/Htomsik");
    }
    
}