using System;
using ProjectMateTask.VMD.Base;

namespace ProjectMateTask.Stores.AppInfrastructure.NavigationStores.Base;

/// <summary>
///     Базовая реализация навмгационного хранилища
/// </summary>
/// <typeparam name="TVmd">Любая тип, наследуемый от BaseVmd</typeparam>
internal class BaseNavigationStore<TVmd> : INavigationStore<TVmd> where TVmd : BaseVmd
{
    private Lazy<TVmd?> _currentVmd;

    public TVmd? CurrentVmd
    {
        get => _currentVmd?.Value;
        set
        {
            _currentVmd?.Value?.Dispose();
            _currentVmd = new Lazy<TVmd?>(()=>value);
            OnCurrentVmdChanged();
        }
    }

    public event Action? CurrentVmdChanged;

    /// <summary>
    ///     Метод, обновляющий увидомитель
    /// </summary>
    protected virtual void OnCurrentVmdChanged() => CurrentVmdChanged?.Invoke();
   
}