using System;

namespace ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base;

internal interface ITypeNavigationServices : ICloseNavigationServices
{
    void Navigate(Type vmdType);
    
}