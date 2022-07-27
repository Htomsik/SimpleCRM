using System;
using ProjectMateTask.VMD.Base;

namespace ProjectMateTask.Stores.AppInfrastructure.NavigationStores.Base;

internal interface INavigationStore
{
    public BaseVmd CurrentVmd { get; set; }

    public event Action CurrentVmdChanged;
}