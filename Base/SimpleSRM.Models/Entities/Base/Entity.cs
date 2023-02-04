using System.ComponentModel.DataAnnotations;

namespace SimpleSRM.Models.Entities.Base;

/// <summary>
///     Базовая реализация неизвестных Entity
/// </summary>
public class Entity : IEntity
{
    [Key]
    public int Id { get; set; }
    public virtual object Clone() => MemberwiseClone();
    
    public bool Equals(object other)
    {
        if (other == null)
            return false;

        if (ReferenceEquals(this, other))
            return true;

        if (GetType() != other.GetType())
            return false;

        return Equals(other as IEntity);
    }

    /// <summary>
    ///     Метод сравнения для наследников, входит в состав общей системы сравнения
    /// </summary>
    /// <param name="other">Entity с которой сравнивают</param>
    /// <returns></returns>
    protected virtual bool Equals(IEntity other)
    {
        if (Id.Equals(other.Id))
            return true;
        return false;
    }
}