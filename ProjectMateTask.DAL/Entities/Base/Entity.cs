namespace ProjectMateTask.DAL.Entities.Base;

public abstract class Entity : IEntity
{
    public virtual object Clone()
    {
        return MemberwiseClone();
    }

    public int Id { get; set; }

    protected virtual bool Equals(IEntity other)
    {
        if (Id.Equals(other.Id))
            return true;
        return false;
    }

   public  bool  Equals(object other)
    {
        if (other == null)
            return false;

        if (ReferenceEquals(this, other))
            return true;

        if (GetType() != other.GetType())
            return false;

        return Equals(other as IEntity);
    }
}