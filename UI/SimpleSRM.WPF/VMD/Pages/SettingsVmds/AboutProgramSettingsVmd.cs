using Microsoft.Extensions.Configuration;
using SimpleSRM.WPF.VMD.Base;

namespace SimpleSRM.WPF.VMD.Pages.SettingsVmds;

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
    
    public string AppVersion => _configuration["AppInfo:AppVersion"] ?? "Не удалось определить версию. Файл конфигурации поврежден.";
}