using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.CloseNavigationServices;

namespace ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.NavigationServices;

/// <summary>
///     Сервис навигации
/// </summary>
internal interface INavigationService : ICloseNavigationServices
{
    /// <summary>
    ///     Метод навигации
    /// </summary>
    public void Navigate();
    
}