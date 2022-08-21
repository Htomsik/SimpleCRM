using System;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.CloseNavigationServices;

namespace ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.TyeNavigationServices;

internal interface ITypeNavigationServices : ICloseNavigationServices
{
    void Navigate(Type vmdType);
    
}