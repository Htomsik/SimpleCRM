
using ProjectMateTask.DAL.Entities.Base;
using ProjectMateTask.DAL.Entities.Types;

namespace ProjectMateTask.DAL.Entities;

public class Client: NamedEntity
{
    public ClientType Type { get; }
    
    public Manager Manager { get; }

    private ICollection<Product> Products { get; }

    public Client(int id, string name, ClientType type, Manager manager, ICollection<Product> products = null)
    {
        Id = id;
        
        Name = name;
        
        Type = type;
        
        Manager = manager;
        
        Products = products;
    }
    
    
}