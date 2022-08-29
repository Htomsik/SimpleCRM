using System;
using ProjectMateTask.Infrastructure.CMD.Base;
using ProjectMateTask.Services.AppInfrastructure;
using ProjectMateTaskExtensions.Services;

namespace ProjectMateTask.Infrastructure.CMD.AppInfrastructure;

/// <summary>
///     Команда отрытия ссылки в браузере
/// </summary>
internal sealed class OpenBrowserLinkCmd : BaseCmd
{
    private readonly Lazy<string>  UrlLink;

    /// <summary>
    ///     Конструктор со ссылкой
    /// </summary>
    /// <param name="urlLink">Ссылка на сайт</param>
    /// <exception cref="ArgumentNullException">Возникает в случе если ссылка пустая</exception>
    public OpenBrowserLinkCmd(string urlLink)
    {
        UrlLink = !string.IsNullOrEmpty(urlLink) ? new Lazy<string>(()=>urlLink) :
            throw new ArgumentNullException(nameof(UrlLink));;
    }

    protected override void Execute(object? parameter) => Link.OpenInBrowser(UrlLink.Value);
  
}