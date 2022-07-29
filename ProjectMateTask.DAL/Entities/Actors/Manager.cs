using ProjectMateTask.DAL.Entities.Base;

namespace ProjectMateTask.DAL.Entities.Actors;

public sealed class Manager:NamedEntity
{
    public ICollection<Client> Clients { get; set; }

}