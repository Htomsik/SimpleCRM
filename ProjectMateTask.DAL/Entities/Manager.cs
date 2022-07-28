using ProjectMateTask.DAL.Entities.Base;

namespace ProjectMateTask.DAL.Entities;

public sealed class Manager:NamedEntity
{
    public ICollection<Client> Clients { get; }

    public Manager(int id, string name, ICollection<Client> clients)
    {
        Id = id;
        
        Name = name;
        
        Clients = clients;
    }
}