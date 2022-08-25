using System;
using ProjectMateTask.VMD.Base;

namespace ProjectMateTask.Stores.AppInfrastructure.NavigationStores.Base;

/// <summary>
///     Навигационное хранилище
/// </summary>
/// <typeparam name="TVmd">Любой тип, наследуемый от BaseVmd</typeparam>
internal interface INavigationStore<TVmd> where TVmd: BaseVmd
{
    /// <summary>
    ///     Текущее значение хранилища
    /// </summary>
    public TVmd? CurrentVmd { get; set; }

    /// <summary>
    ///     уведомитель об изменении
    /// </summary>
    public event Action CurrentVmdChanged;
}