namespace ProjectMateTask.DAL.Entities.Base;

public abstract class Entity : IEntity, ICloneable, IEquatable<Entity>
{
    public virtual object Clone()
    {
        return MemberwiseClone();
    }

    public int Id { get; set; }

    public bool Equals(Entity other)
    {
        if (other == null)
            return false;

        if (ReferenceEquals(this, other))
            return true;

        if (GetType() != other.GetType())
            return false;

        if (Id.Equals(other.Id))
            return true;
        return false;
    }

    public override bool Equals(object other)
    {
        if (other == null)
            return false;

        if (ReferenceEquals(this, other))
            return true;

        if (GetType() != other.GetType())
            return false;

        return Equals(other as Entity);
    }
}