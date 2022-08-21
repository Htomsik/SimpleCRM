using System;
using ProjectMateTask.Stores.Base;
using ProjectMateTask.VMD.Base;

namespace ProjectMateTask.Stores.AppInfrastructure.NavigationStores.Base;

internal abstract class BaseNavigationStore<TVmd> : INavigationStore<TVmd> where TVmd : BaseVmd
{
    private TVmd? _currentVmd;

    public TVmd? CurrentVmd
    {
        get => _currentVmd;
        set
        {
            _currentVmd?.Dispose();
            _currentVmd = value;
            OnCurrentVmdChanged();
        }
    }

    public event Action? CurrentVmdChanged;

    protected virtual void OnCurrentVmdChanged()
    {
        CurrentVmdChanged?.Invoke();
    }
}