using System.ComponentModel.DataAnnotations;
using ProjectMateTask.DAL.Entities.Base;
using ProjectMateTask.DAL.Entities.Types;

namespace ProjectMateTask.DAL.Entities.Actors;

public sealed class Product : NamedEntity
{
    [Required] public ProductType Type { get; set; }

    public ICollection<Client> Clients { get; set; }
    
    public override bool Equals(object other)
    {
        if (other == null)
            return false;

        if (ReferenceEquals(this, other))
            return true;

        if (GetType() != other.GetType())
            return false;

        return Equals(other as Product);
    }

    public bool Equals(Product other)
    {
        if (other == null)
            return false;

        if (ReferenceEquals(this, other))
            return true;

        if (GetType() != other.GetType())
            return false;

        if (base.Equals(other) && Type.Equals(other.Type) && Equals(Clients, other.Clients))
            return true;
        return false;
    }
}