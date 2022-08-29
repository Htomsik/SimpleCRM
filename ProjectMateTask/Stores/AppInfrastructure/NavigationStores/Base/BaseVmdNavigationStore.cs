using System;
using ProjectMateTask.VMD.Base;

namespace ProjectMateTask.Stores.AppInfrastructure.NavigationStores.Base;

/// <summary>
///     Базовая реализация навигационного хранилища для обобщенных типов
/// </summary>
/// <typeparam name="TVmd">Любая тип, наследуемый от BaseVmd</typeparam>
internal class BaseVmdNavigationStore<TVmd> : IVmdNavigationStore<TVmd> where TVmd : BaseVmd
{
    private Lazy<TVmd?> _currentVmd;

    public TVmd? CurrentValue
    {
        get => _currentVmd?.Value;
        set
        {
            _currentVmd?.Value?.Dispose();
            _currentVmd = new Lazy<TVmd?>(() => value);
            OnCurrentVmdChanged();
        }
    }

    public event Action? CurrentValueChanged;

    /// <summary>
    ///     Метод, обновляющий увидомитель
    /// </summary>
    protected virtual void OnCurrentVmdChanged()
    {
        CurrentValueChanged?.Invoke();
    }
}