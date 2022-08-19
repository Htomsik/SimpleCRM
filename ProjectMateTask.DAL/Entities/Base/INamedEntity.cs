using System.ComponentModel;

namespace ProjectMateTask.DAL.Entities.Base;

public interface INamedEntity : IEntity, INotifyPropertyChanged,INotifyDataErrorInfo
{
    string Name { get; set; } 
}