using System.Diagnostics;

namespace ProjectMateTask.Services.AppInfrastructure;

/// <summary>
///     Сервис работы со ссылками
/// </summary>
internal static class Link
{
    /// <summary>
    ///     Открытие ссылки в браузере (Только для виндовс)
    /// </summary>
    /// <param name="UrlLink"></param>
    public static void OpenInBrowser(string? UrlLink)
    {
        if (UrlLink is null) return;
        Process.Start(new ProcessStartInfo(UrlLink) { UseShellExecute = true });
        
    }
}