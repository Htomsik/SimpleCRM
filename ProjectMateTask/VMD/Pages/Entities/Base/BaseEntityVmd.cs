using System.ComponentModel;
using System.Windows.Data;
using ProjectMateTask.VMD.Base;

namespace ProjectMateTask.VMD.Pages.Entities.Base;

/// <summary>
///     Базовый реализация для EntityVmd типов
/// </summary>
internal abstract class BaseEntityVmd : BaseVmd, IEntityVmd
{
    
    #region EntitiesFilteredView : фильтрованный список Entity

    protected CollectionViewSource _entitiesViewSource;

    /// <summary>
    ///     Коллекция фильтрованных Entity
    /// </summary>
    public virtual ICollectionView? EntitiesFilteredView => _entitiesViewSource?.View;

    #endregion
}