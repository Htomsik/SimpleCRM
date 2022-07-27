using System;
using ProjectMateTask.VMD.Base;

namespace ProjectMateTask.Stores.AppInfrastructure.NavigationStores.Base;

internal abstract class BaseNavigationStore : INavigationStore
{
    private BaseVmd _currentVmd;

    public BaseVmd CurrentVmd
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