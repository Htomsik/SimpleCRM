using System;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores.Base;
using ProjectMateTask.Stores.Base;
using ProjectMateTask.VMD.Base;

namespace ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.TypeNavigationServices;

/// <summary>
///     Базовая реализация севиса навигации по типам
/// </summary>
/// <typeparam name="TVmd">Любой тип, наследуемый от BaseVmd</typeparam>
internal  class BaseTypeNavigationServices<TVmd>:ITypeNavigationServices where TVmd: BaseVmd
{
    private readonly Lazy<IVmdNavigationStore<TVmd>>  _navigationStore;

    /// <summary>
    ///     Базовая реализация севиса навигации по типам
    /// </summary>
    /// <param name="vmdNavigationStore">Навигационное хранилище</param>
    /// <exception cref="ArgumentNullException">Возникает в случае если vmdNavigationStore null</exception>
    public BaseTypeNavigationServices(IVmdNavigationStore<TVmd> vmdNavigationStore)
    {
        _navigationStore = new Lazy<IVmdNavigationStore<TVmd>>(vmdNavigationStore)
            ?? throw new ArgumentNullException(nameof(_navigationStore));
    }
    
    /// <summary>
    ///     Метод навигации
    /// </summary>
    /// <param name="vmdType">Тип, заренистирированный в IOC контейнере</param>
    /// <exception cref="ArgumentNullException">Возникает в случае если не найдено регистрации для типа</exception>
    public virtual void Navigate(Type vmdType)
    {
        var iocVmd = (TVmd)App.Services.GetService(vmdType);

      _navigationStore.Value.CurrentValue = iocVmd ??
          throw new ArgumentNullException($"Отсуствует зарегистрированная Viewmodel для {vmdType}");

    }

    public void Close()
    {
        _navigationStore.Value.CurrentValue = null;
    }
}