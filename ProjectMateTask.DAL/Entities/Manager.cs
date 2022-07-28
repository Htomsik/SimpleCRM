using ProjectMateTask.DAL.Entities.Base;

namespace ProjectMateTask.DAL.Entities;

public sealed class Manager:NamedEntity
{
    public ICollection<Client> Clients { get; set; }

}