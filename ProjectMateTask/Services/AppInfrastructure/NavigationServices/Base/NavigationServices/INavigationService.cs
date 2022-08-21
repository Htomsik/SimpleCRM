using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.CloseNavigationServices;

namespace ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.NavigationServices;

internal interface INavigationService : ICloseNavigationServices
{
    public void Navigate();

   
}