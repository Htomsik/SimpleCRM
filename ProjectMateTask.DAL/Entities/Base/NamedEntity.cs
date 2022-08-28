using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectMateTask.DAL.Entities.Base;

/// <summary>
///     Базовая реализация Entity c известным типом в бд
/// </summary>
public abstract class NamedEntity : Entity, INamedEntity
{
    #region Конструкторы

    /// <summary>
    ///     Конструктор для случаев когда известны все атрибуты NamedEntity (обычно используется для импорта Entity из бд)
    /// </summary>
    /// <param name="id">Идентификатор</param>
    /// <param name="name">Название</param>
    public NamedEntity(int id, string name):this(name)
    {
        Id = id;
    }
    
    /// <summary>
    ///     Конструктор для случаев когда создается новый NamedEntity на основе заранее частично известных атрибутов.
    /// </summary>
    /// <param name="name">Название</param>
    public NamedEntity(string name)
    {
        Name = name;
    }

    /// <summary>
    ///     Конструктор без параметров для создания нового NamedEntity
    /// </summary>
    public NamedEntity()
    {
        Name = string.Empty;
    }

    #endregion
    
    #region Свойства и поля
    
    #region Name : Наименование

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

    #endregion

    /// <summary>
    ///     Список валидационных ошибок для атрибутов
    /// </summary>
    protected Lazy<Dictionary<string, List<string>>> errors =
        new ();

    #endregion

    #region Методы

    /// <summary>
    ///     Проверка валидации для Name
    /// </summary>
    /// <param name="value">Значение</param>
    /// <param name="propertyName">Имя вызывающего атрибута</param>
    protected void CheckNameErrors(string value, [CallerMemberName] string? propertyName = null)
    {
      var lazyErrors = new Lazy<List<string>>();
      
        switch (value)
        {
              
            case { } n when string.IsNullOrEmpty(n):
                lazyErrors.Value.Add("Требуемый тип");
                break;
                
            case { Length: < 2 }:
                lazyErrors.Value.Add("Имя не может быть меньше 2");
                break;
                
            case { Length: > 150 }:
                lazyErrors.Value.Add("Имя не может быть больше 150");
                break;

            default:
                ClearErrors(propertyName);
                break;
        }
        if (lazyErrors.IsValueCreated)
        {
            SetErrors(lazyErrors.Value,propertyName);
        }
    }
    
    
    /// <summary>
    ///     Установка ошибок для атрибутов
    /// </summary>
    /// <param name="propertyErrors">Коллекция устанавливааемых ошибок</param>
    /// <param name="propertyName">Имя атрибута которому будет происходить установка ошибок</param>
    private void SetErrors(List<string> propertyErrors,[CallerMemberName]string? propertyName = null)
    {
        errors.Value.Remove(propertyName!);
        errors.Value.Add(propertyName!, propertyErrors);
    }
    
    /// <summary>
    ///     Очистка ошибок атрибутов
    /// </summary>
    /// <param name="propertyName">Имя атрибута которому будет происходить удаление ошибок</param>
    private void ClearErrors([CallerMemberName]string? propertyName = null)
    {
        if (errors.IsValueCreated && errors.Value.Count >0)
        {
            errors.Value.Remove(propertyName!);
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            errors = new Lazy<Dictionary<string, List<string>>>();
        }
        
    }

    /// <summary>
    ///     Метод проверки валидации для наследников
    /// </summary>
    /// <returns></returns>
    protected virtual bool SubHasErrors() => false;
    
    
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

    #endregion
    
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

    public IEnumerable GetErrors(string? propertyName)
    {
        switch (propertyName)
        {
            case { } n when string.IsNullOrEmpty(n):
                    return (errors.Value.Values);
              
            case { } n when errors.Value.ContainsKey(n):
                return (errors.Value[propertyName]);
            
            default:
                return null!;
                
        }
        
    }
    
    [NotMapped]
    public bool HasErrors
    {
        get
        { 
            CheckNameErrors(Name,nameof(Name));
            return errors.Value.Count > 0 || SubHasErrors();
        }
    }
    
    public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;
    
    #endregion
    
}