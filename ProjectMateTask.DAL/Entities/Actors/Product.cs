using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using ProjectMateTask.DAL.Entities.Base;
using ProjectMateTask.DAL.Entities.Types;
using ProjectMateTask.DAL.Services;

namespace ProjectMateTask.DAL.Entities.Actors;

public sealed class Product : NamedEntity
{
    public Product()
    {
    }

    public Product(int id, string name, ProductType productType, ICollection<Client> clients) : base(id, name)
    {
        Type = productType;
        Clients = clients;
    }

    public Product(int id, string name, ProductType productType) : base(id, name)
    {
        Type = productType;
    }

    [Required] public ProductType Type { get; set; }

    public ICollection<Client> Clients { get; set; } = new ObservableCollection<Client>();

    protected override bool Equals(IEntity other)
    {
        var otherEntity = other as Product;

        if (otherEntity is null)
            throw new TypeAccessException(
                $"Неправильный тип данных, требуемый тип: {GetType()}, фактический тип: {other.GetType()}");

        if (!base.Equals(other) || !Type.Equals(otherEntity.Type)) return false;

        return EntityServices<Client>.IsCollectionsEqualsNoDeep(Clients, otherEntity.Clients);
    }

    public override object Clone()
    {
        return new Product(Id,
            Name,
            Type,
            new ObservableCollection<Client>(
                Clients.Select(item => item).ToArray()
            ));
    }
}