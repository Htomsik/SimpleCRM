using System.ComponentModel.DataAnnotations;

namespace ProjectMateTask.DAL.Entities.Base;

public abstract class NamedEntity : Entity
{
    [Required] public string Name { get; set; }

    public override bool Equals(object other)
    {
        if (other == null)
            return false;

        if (ReferenceEquals(this, other))
            return true;

        if (GetType() != other.GetType())
            return false;

        return Equals(other as NamedEntity);
    }

    public bool Equals(NamedEntity other)
    {
        if (other == null)
            return false;

        if (ReferenceEquals(this, other))
            return true;

        if (GetType() != other.GetType())
            return false;

        if (base.Equals(other) && string.Compare(Name, other.Name, StringComparison.CurrentCulture) == 0)
            return true;
        return false;
    }
}