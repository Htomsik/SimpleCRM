﻿using System.Diagnostics;

namespace SimpleSRM.Extensions.Services;

/// <summary>
///     Сервис работающий со ссылками
/// </summary>
public static class LinkExstensions
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