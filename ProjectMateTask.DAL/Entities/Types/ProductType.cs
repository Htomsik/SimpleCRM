using System.Collections.ObjectModel;
using ProjectMateTask.DAL.Entities.Actors;
using ProjectMateTask.DAL.Entities.Base;
using ProjectMateTask.DAL.Entities.Services;

namespace ProjectMateTask.DAL.Entities.Types;

public sealed class ProductType : NamedEntity
{
    public ProductType()
    {
    }

    public ProductType(int id, string name, ICollection<Product> products)
    {
        Id = id;
        Name = name;
        Products = products;
    }

    public ProductType(int id, string name) : base(id, name)
    {
    }

    public ICollection<Product> Products { get; set; } = new ObservableCollection<Product>();

    protected override bool Equals(IEntity other)
    {
        var otherEntity = other as ProductType;

        if (otherEntity is null)
            throw new TypeAccessException(
                $"Неправильный тип данных, требуемый тип: {GetType()}, фактический тип: {other.GetType()}");

        if (!base.Equals(other)) return false;

        return EntityServices<Product>.IsCollectionsEqualsNoDeep(Products, otherEntity.Products);
    }

    public override object Clone()
    {
        return new ProductType(Id,
            Name,
            new ObservableCollection<Product>(
                Products.Select(item => item).ToArray()
            ));
    }
}