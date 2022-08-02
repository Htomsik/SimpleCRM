using System.Collections.ObjectModel;
using ProjectMateTask.DAL.Entities.Actors;
using ProjectMateTask.DAL.Entities.Base;

namespace ProjectMateTask.DAL.Entities.Types;

public sealed class ProductType : NamedEntity
{
    public ICollection<Product> Products { get; set; }
    
    protected override bool Equals(IEntity other)
    {
        var otherEntity = other as ProductType;

        if (otherEntity is null )
        {
            throw new TypeAccessException($"Неправильный тип данных, требуемый тип: {this.GetType()}, фактический тип: {other.GetType()}");
        }

        if (!base.Equals(other) || Products.Count != otherEntity.Products.Count) return false;
        
        return Products.Any(origin => otherEntity.Products.Any(copy => copy.Id != origin.Id));
        
    }
    
    
    public ProductType(){}

    public ProductType(int id, string name,ICollection<Product> products)
    {
        Id = id;
        Name = name;
        Products = products;
    }
    
    public override object Clone() =>
        new ProductType(this.Id,
            this.Name,
            new ObservableCollection<Product>(
                Products.Select(item => item).ToArray()
            ));


  
    
}