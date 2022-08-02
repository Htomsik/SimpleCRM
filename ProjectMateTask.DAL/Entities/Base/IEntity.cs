namespace ProjectMateTask.DAL.Entities.Base;

public interface IEntity: ICloneable, IEquatable<object>
{
    int Id { get; set; }
}