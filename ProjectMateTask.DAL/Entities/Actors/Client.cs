using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using ProjectMateTask.DAL.Entities.Base;
using ProjectMateTask.DAL.Entities.Types;

namespace ProjectMateTask.DAL.Entities.Actors;

public sealed class Client : NamedEntity
{
    [Required] 
    public ClientStatus Status { get; set; }

    public Manager Manager { get; set; }

    public ICollection<Product> Products { get; set; } = new ObservableCollection<Product>();
    
    protected override bool Equals(IEntity other)
    {
        var otherProductEntity = other as Client;

        if (otherProductEntity is null )
        {
            throw new TypeAccessException($"Неправильный тип данных, требуемый тип: {this.GetType()}, фактический тип: {other.GetType()}");
        }
        
        if (Status.Equals(otherProductEntity.Status) 
            && Manager.Equals(otherProductEntity.Manager) 
            && !Products.Except(otherProductEntity.Products).Any())
            return true;
        return false;
    }
    
    
   public Client(){}

   public Client(int id, string name, ClientStatus clientStatus, Manager manager, ICollection<Product> products)
   {
       Id = id;
       Name = name;
       Status = clientStatus;
       Manager = manager;
       Products = products;

   }

   public override object Clone() =>
       new Client(this.Id,
           this.Name,
           this.Status,
           this.Manager,
           new ObservableCollection<Product>(
               Products.Select(item => item).ToArray()
           ));


}