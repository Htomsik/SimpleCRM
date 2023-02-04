using System.ComponentModel;

namespace SimpleSRM.WPF.VMD.Pages.Entities.Base;

/// <summary>
///     Модель представления для Entity типов
/// </summary>
public interface IEntityVmd : INotifyPropertyChanged
{
    /// <summary>
    ///     Список Entity
    /// </summary>
    public ICollectionView? EntitiesFilteredView { get;}
    
}