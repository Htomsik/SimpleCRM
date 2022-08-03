using System.ComponentModel.DataAnnotations;

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

    [Required] public string Name { get; set; }


    protected override bool Equals(IEntity other)
    {
        var otherNamedEntity = other as NamedEntity;

        if (base.Equals(other) && string.Compare(Name, otherNamedEntity!.Name, StringComparison.CurrentCulture) == 0)
            return true;
        return false;
    }
}