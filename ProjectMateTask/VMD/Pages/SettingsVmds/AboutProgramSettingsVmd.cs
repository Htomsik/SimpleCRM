using Microsoft.Extensions.Configuration;
using ProjectMateTask.VMD.Base;

namespace ProjectMateTask.VMD.Pages.SettingsVmds;

/// <summary>
///     Блок о программе для настроек (SettingsAdditionalPageVmd)
/// </summary>
internal sealed class AboutProgramVmd : BaseVmd
{
    private readonly IConfiguration _configuration;

    /// <summary>
    ///     Блок о программе для настроек (SettingsAdditionalPageVmd)
    /// </summary>
    /// <param name="configuration">Информция из конфигурационного файла</param>
    public AboutProgramVmd(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string AppVersion => _configuration["AppInfo:AppVersion"];
}