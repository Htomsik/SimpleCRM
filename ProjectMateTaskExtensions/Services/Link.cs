using System.Diagnostics;

namespace ProjectMateTaskExtensions.Services;

/// <summary>
///     Сервис работающий со ссылками
/// </summary>
public static class Link
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