using System.ComponentModel;
using System.Windows.Data;
using SimpleSRM.WPF.VMD.Base;

namespace SimpleSRM.WPF.VMD.Pages.Entities.Base;

/// <summary>
///     Базовый реализация для EntityVmd типов
/// </summary>
public class BaseEntityVmd : BaseVmd, IEntityVmd
{
    
    #region EntitiesFilteredView : фильтрованный список Entity

    protected CollectionViewSource _entitiesViewSource;

    /// <summary>
    ///     Коллекция фильтрованных Entity
    /// </summary>
    public virtual ICollectionView? EntitiesFilteredView => _entitiesViewSource?.View;

    #endregion
}