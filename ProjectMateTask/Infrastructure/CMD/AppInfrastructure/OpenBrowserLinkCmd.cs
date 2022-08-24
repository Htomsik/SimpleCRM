using ProjectMateTask.Infrastructure.CMD.Base;
using ProjectMateTask.Services.AppInfrastructure;

namespace ProjectMateTask.Infrastructure.CMD.AppInfrastructure;

internal sealed class OpenBrowserLinkCmd : BaseCmd
{
    private string UrlLink;

    public OpenBrowserLinkCmd(string urlLink)
    {
        UrlLink = urlLink;
    }
    protected override void Execute(object? parameter) => Link.OpenInBrowser(UrlLink);
    
}