using System;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.CloseNavigationServices;

namespace ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.TypeNavigationServices;

internal interface ITypeNavigationServices : ICloseNavigationServices
{
    void Navigate(Type vmdType);
    
}