using System;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.CloseNavigationServices;

namespace ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.TypeNavigationServices;

/// <summary>
///     Сервис навигации по типам
/// </summary>
internal interface ITypeNavigationServices : ICloseNavigationServices
{
    /// <summary>
    ///     Метод навигации
    /// </summary>
    /// <param name="vmdType">Тип по которому произойдет навигация</param>
    void Navigate(Type vmdType);
    
}