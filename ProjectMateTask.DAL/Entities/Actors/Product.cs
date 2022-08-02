using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using ProjectMateTask.DAL.Entities.Base;
using ProjectMateTask.DAL.Entities.Types;

namespace ProjectMateTask.DAL.Entities.Actors;

public sealed class Product : NamedEntity
{
    [Required] public ProductType Type { get; set; }

    public ICollection<Client> Clients { get; set; } = new ObservableCollection<Client>();
    
    protected override bool Equals(IEntity other)
    {
        var otherEntity = other as Product;

        if (otherEntity is null )
        {
            throw new TypeAccessException($"Неправильный тип данных, требуемый тип: {this.GetType()}, фактический тип: {other.GetType()}");
        }
        
        
        if (!base.Equals(other) || !Type.Equals(otherEntity.Type) || Clients.Count != otherEntity.Clients.Count) return false;
            
        return Clients.Any(origin => otherEntity.Clients.Any(copy => copy.Id != origin.Id));
        
    }

    public override object Clone() =>
        new Product(this.Id,
        this.Name,
        this.Type,
        new ObservableCollection<Client>(
            Clients.Select(item => item).ToArray()
        ));
    
    
    public Product(){}

    public Product(int id,string name, ProductType productType, ICollection<Client> clients)
    {
        Id = id;
        Name = name;
        Type = productType;
        Clients = clients;
    }
   
}