using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using ProjectMateTask.DAL.Annotations;
using ProjectMateTask.DAL.Entities.Base;
using ProjectMateTask.DAL.Entities.Types;
using ProjectMateTask.DAL.Services;
using ProjectMateTask.DAL.Stores;

namespace ProjectMateTask.DAL.Entities.Actors;

public sealed class Client : NamedEntity
{
    #region Конструкторы

    public Client()
    {
        Status = new ClientStatus();
        Manager = new Manager();
    }

    public Client(int id, string name, ClientStatus clientStatus, Manager manager, ICollection<Product> products) :
        this(id, name, clientStatus, manager)
    {
        Products = new EntityCollectionStore<Product>(products);
    }

    public Client(int id, string name) : base(id, name)
    {
    }

    public Client(int id, string name, ClientStatus clientStatus, Manager manager) : this(id, name, clientStatus)
    {
        Manager = manager;
    }

    public Client(int id, string name, ClientStatus clientStatus) : base(id, name)
    {
        Status = clientStatus;
    }

    #endregion

    #region Status : статус/тип клиента

    private ClientStatus _status;

    [Required]
    public ClientStatus Status
    {
        get => _status;
        set => Set(ref _status,value);
    }

    #endregion

    #region Manager : cвязаный менедже

    private Manager _manager;
    public Manager Manager 
    { 
        get => _manager; 
        set => Set(ref _manager,value); 
    }

    #endregion
    
    public ICollection<Product> Products { get; set; } = new EntityCollectionStore<Product>();

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
            new EntityCollectionStore<Product>(
                Products.Select(item => item)
            ));
    }
}

   