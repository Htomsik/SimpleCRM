using System.ComponentModel;

namespace ProjectMateTask.VMD.Pages.Entities.Base;

/// <summary>
///     Модель представления для Entity типов
/// </summary>
internal interface IEntityVmd : INotifyPropertyChanged
{
    /// <summary>
    ///     Список Entity
    /// </summary>
    public ICollectionView? EntitiesFilteredView { get;}
    
    /// <summary>
    ///     Название страницы или используемого типа
    /// </summary>
    string Tittle { get; }
}