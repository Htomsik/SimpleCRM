using System.ComponentModel.DataAnnotations;
using ProjectMateTask.DAL.Entities.Base;
using ProjectMateTask.DAL.Entities.Types;
using ProjectMateTask.DAL.Services;
using ProjectMateTask.DAL.Stores;

namespace ProjectMateTask.DAL.Entities.Actors;

public sealed class Product : NamedEntity
{
    #region Конструкторы

    public Product()
    {
        Type = new ProductType();
    }

    public Product(int id, string name, ProductType productType, ICollection<Client> clients) : base(id, name)
    {
        Type = productType;
        Clients = new EntityCollectionStore<Client>(clients);
    }

    public Product(int id, string name, ProductType productType) : base(id, name)
    {
        Type = productType;
    }

    #endregion
    
    #region Type : тип продукта

    private ProductType _type;

    [Required]
    public ProductType Type
    {
        get => _type;
        set => Set(ref _type,value);
    }

    #endregion
    
    public ICollection<Client> Clients { get; set; } = new EntityCollectionStore<Client>();

    protected override bool Equals(IEntity other)
    {
        var otherEntity = other as Product;

        if (otherEntity is null)
            throw new TypeAccessException(
                $"Неправильный тип данных, требуемый тип: {GetType()}, фактический тип: {other.GetType()}");

        if (!base.Equals(other) || !Type.Equals(otherEntity.Type)) return false;

        return EntityServices<Client>.IsCollectionsEqualsNoDeep(Clients, otherEntity.Clients);
    }

    protected override bool SubHasErrors() => Type.HasErrors;
    
    public override object Clone()
    {
        return new Product(Id,
            Name,
            Type,
            new EntityCollectionStore<Client>(
                Clients.Select(item => item)
            ));
    }
}