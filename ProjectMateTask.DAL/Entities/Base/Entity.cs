namespace ProjectMateTask.DAL.Entities.Base;

public abstract class Entity:IEntity
{
    public int Id { get; protected set; }
    
}