using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using ProjectMateTask.DAL.Annotations;

namespace ProjectMateTask.DAL.Entities.Base;

public abstract class NamedEntity : Entity, INamedEntity
{
    public NamedEntity(int id, string name)
    {
        Id = id;

        Name = name;
    }

    public NamedEntity()
    {
    }


    private string _name;

    [Required]
    public string Name
    {
        get => _name;
        set => Set(ref _name, value);
    }


    protected override bool Equals(IEntity other)
    {
        var otherNamedEntity = other as NamedEntity;

        if (base.Equals(other) && string.Compare(Name, otherNamedEntity!.Name, StringComparison.CurrentCulture) == 0)
            return true;
        return false;
    }


    #region INPC

    public event PropertyChangedEventHandler? PropertyChanged;
    
    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    
    protected bool Set<T>(ref T field, T value,[CallerMemberName] string? propertyName = null)
    {
        if (Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }

    #endregion
   
}