using ProjectMateTask.DAL.Entities.Base;
using ProjectMateTask.DAL.Entities.Types;

namespace ProjectMateTask.DAL.Entities;

public class Product:NamedEntity
{
    public double Price { get; }
    
    public ProductType Type { get; }

    public Product(int id, string name, double price, ProductType type)
    {
        Id = id;
        Name = name;
        Price = price;
        Type = type;
    }
    
}