using ProjectMateTask.DAL.Entities.Actors;
using ProjectMateTask.DAL.Entities.Base;
using ProjectMateTask.DAL.Services;
using ProjectMateTask.DAL.Stores;

namespace ProjectMateTask.DAL.Entities.Types;

public sealed class ProductType : NamedEntity
{

    #region Конструкторы

    public ProductType()
    {
    }
    
    public ProductType(string name):base(name)
    {
    }

    public ProductType(int id, string name, ICollection<Product> products)
    {
        Id = id;
        Name = name;
        Products = new EntityCollectionStore<Product>(products);
    }

    public ProductType(int id, string name) : base(id, name)
    {
    }

    #endregion
    
    public ICollection<Product> Products { get; set; } = new EntityCollectionStore<Product>();

    protected override bool Equals(IEntity other)
    {
        var otherEntity = other as ProductType;

        if (otherEntity is null)
            throw new TypeAccessException(
                $"Неправильный тип данных, требуемый тип: {GetType()}, фактический тип: {other.GetType()}");

        if (!base.Equals(other)) return false;

        return EntityServices<Product>.IsCollectionsEqualsNoDeep(Products, otherEntity.Products);
    }

    protected override bool SubHasErrors() => false;
    

    public override object Clone()
    {
        return new ProductType(Id,
            Name,
            new EntityCollectionStore<Product>(
                Products.Select(item => item).ToArray()
            ));
    }
}