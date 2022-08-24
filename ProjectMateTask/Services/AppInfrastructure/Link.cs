using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ProjectMateTask.Services.AppInfrastructure;

internal static class Link
{
    public static void OpenInBrowser(string? UrlLink)
    {
        if (UrlLink is null) return;
        Process.Start(new ProcessStartInfo(UrlLink) { UseShellExecute = true });
        
    }
}