namespace ProjectMateTask.DAL.Entities.Base;

public interface INamedEntity : IEntity
{
    string Name { get; set; }
}