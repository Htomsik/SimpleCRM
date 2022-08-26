using System.ComponentModel;

namespace ProjectMateTask.VMD.Pages.Entities.Base;

internal interface IEntityVmd : INotifyPropertyChanged
{
    public ICollectionView? EntitiesFilteredView { get;}
    
    string Tittle { get; }
}