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
        var otherProductEntity = other as Product;

        if (otherProductEntity is null )
        {
            throw new TypeAccessException($"Неправильный тип данных, требуемый тип: {this.GetType()}, фактический тип: {other.GetType()}");
        }
        
        if (base.Equals(other) && Type.Equals(otherProductEntity!.Type) && !Clients.Except(otherProductEntity.Clients).Any())
            return true;
        return false;
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