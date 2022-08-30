using System;
using ProjectMateTask.Stores.Base;
using ProjectMateTask.VMD.Base;

namespace ProjectMateTask.Stores.AppInfrastructure.NavigationStores.Base;

/// <summary>
///     Базовая реализация навигационного хранилища для обобщенных типов
/// </summary>
/// <typeparam name="TVmd">Любая тип, наследуемый от BaseVmd</typeparam>
internal class BaseVmdNavigationStore<TVmd> : BaseStore<TVmd>, IVmdNavigationStore<TVmd> where TVmd : BaseVmd
{
    public override TVmd? CurrentValue
    {
        get => _currentValue?.Value;
        set
        {
            _currentValue?.Value?.Dispose();
            _currentValue = new Lazy<TVmd?>(() => value);
            OnCurrentValueChanged();
        }
    }
    
}