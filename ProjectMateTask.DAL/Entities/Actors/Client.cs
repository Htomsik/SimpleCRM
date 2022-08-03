using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using ProjectMateTask.DAL.Entities.Base;
using ProjectMateTask.DAL.Entities.Services;
using ProjectMateTask.DAL.Entities.Types;

namespace ProjectMateTask.DAL.Entities.Actors;

public sealed class Client : NamedEntity
{
    public Client()
    {
    }

    public Client(int id, string name, ClientStatus clientStatus, Manager manager, ICollection<Product> products) :
        base(id, name)
    {
        Status = clientStatus;
        Manager = manager;
        Products = products;
    }

    public Client(int id, string name) : base(id, name)
    {
    }
    
    public Client(int id, string name, Manager manager) : base(id, name)
    {
        Manager = manager;
    }

    [Required] public ClientStatus Status { get; set; }

    public Manager Manager { get; set; }

    public ICollection<Product> Products { get; set; } = new ObservableCollection<Product>();

    protected override bool Equals(IEntity other)
    {
        var otherEntity = other as Client;

        if (otherEntity is null)
            throw new TypeAccessException(
                $"Неправильный тип данных, требуемый тип: {GetType()}, фактический тип: {other.GetType()}");

        if (!base.Equals(other)
            || !Manager.Equals(otherEntity.Manager)
            || !Status.Equals(otherEntity.Status)
           )
            return false;

        return EntityServices<Product>.IsCollectionsEqualsNoDeep(Products, otherEntity.Products);
    }

    public override object Clone()
    {
        return new Client(Id,
            Name,
            Status,
            Manager,
            new ObservableCollection<Product>(
                Products.Select(item => item).ToList()
            ));
    }
}