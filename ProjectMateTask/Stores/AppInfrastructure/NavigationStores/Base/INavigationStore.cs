using System;
using ProjectMateTask.VMD.Base;

namespace ProjectMateTask.Stores.AppInfrastructure.NavigationStores.Base;

internal interface INavigationStore<TVmd> where TVmd: BaseVmd
{
    public TVmd? CurrentVmd { get; set; }

    public event Action CurrentVmdChanged;
}