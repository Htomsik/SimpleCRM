using System;
using SimpleSRM.WPF.Services.AppInfrastructure.NavigationServices.Base.CloseNavigationServices;

namespace SimpleSRM.WPF.Services.AppInfrastructure.NavigationServices.Base.TypeNavigationServices;

/// <summary>
///     Сервис навигации по типам
/// </summary>
public interface ITypeNavigationServices : ICloseNavigationServices
{
    /// <summary>
    ///     Метод навигации
    /// </summary>
    /// <param name="vmdType">Тип по которому произойдет навигация</param>
    void Navigate(Type vmdType);
    
}