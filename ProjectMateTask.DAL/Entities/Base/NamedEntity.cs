using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectMateTask.DAL.Entities.Base;

public abstract class NamedEntity : Entity, INamedEntity
{
    public NamedEntity(int id, string name):this(name)
    {
        Id = id;
        
    }
    
    public NamedEntity(string name)
    {
        Name = name;
    }

    public NamedEntity()
    {
        Name = string.Empty;
    }


    private string _name;
    
    [Required]
    [MinLength(2)]
    [MaxLength(150)]
    public string Name
    {
        get
        {
            return _name;
        } 
        set
        {
            Set(ref _name, value);
          
        }
            
    }
    
    private void CheckErrors(string value, [CallerMemberName] string propertyName = null)
    {
        Lazy<List<string>> errors = new Lazy<List<string>>();
        switch (value)
        {
              
            case string n when string.IsNullOrEmpty(n):
                errors.Value.Add("Требуемый тип");
                break;
                
            case string n when n.Length < 2:
                errors.Value.Add("Имя не может быть меньше 2");
                break;
                
            case string n when n.Length > 150:
                errors.Value.Add("Имя не может быть больше 150");
                break;

            default:
                ClearErrors(propertyName);
                break;
        }
        if (errors.IsValueCreated)
        {
            SetErrors(errors.Value,propertyName);
        }
    }
    
    protected override bool Equals(IEntity other)
    {
        var otherNamedEntity = other as NamedEntity;

        if (base.Equals(other))
        {
            if (string.IsNullOrEmpty(Name) && string.IsNullOrEmpty(otherNamedEntity!.Name))
                return true;
            
            return string.Compare(Name, otherNamedEntity!.Name, StringComparison.CurrentCulture) == 0;
        }

        return false;
        
    }
    
    #region INotifyPropertyChanged : обновление модели во view

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

    #region INotifyDataErrorInfo : валидация данных

    public  IEnumerable GetErrors(string? propertyName)
    {
        switch (propertyName)
        {
            case string n when string.IsNullOrEmpty(n):
                    return (errors.Value.Values);
              
            case string n when errors.Value.ContainsKey(n):
                return (errors.Value[propertyName]);
            
            default:
                return null;
                
        }
        
    }

    protected void SetErrors(List<string> propertyErrors,[CallerMemberName]string? propertyName = null)
    {
        errors.Value.Remove(propertyName);
        errors.Value.Add(propertyName, propertyErrors);
    }
    
    protected void ClearErrors([CallerMemberName]string? propertyName = null)
    {
        if (errors.IsValueCreated && errors.Value.Count >0)
        {
            errors.Value.Remove(propertyName);
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            errors = new Lazy<Dictionary<string, List<string>>>();
        }
        
    }

    private Lazy<Dictionary<string, List<string>>> errors =
        new Lazy<Dictionary<string, List<string>>>();

    [NotMapped]
    public bool HasErrors
    {
        get
        { 
            CheckErrors(Name,nameof(Name));
            return errors.Value.Count > 0 || SubHasErrors();
        }
    }

    protected abstract bool SubHasErrors();
    
    public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;
    
    #endregion

    
   

    
    
    
}