using System.ComponentModel.DataAnnotations;
using ProjetMateTaskEntities.Entities.Base;
using ProjetMateTaskEntities.Entities.Types;
using ProjetMateTaskEntities.Services;
using ProjetMateTaskEntities.Stores;

namespace ProjetMateTaskEntities.Entities.Actors;

/// <summary>
///     Существующие в бд клиенты с NamedEntity типом
/// </summary>
public sealed class Client : NamedEntity
{
    #region Конструкторы

    /// <summary>
    ///     Конструктор для создания нового клиента без заранее известных атрибутов
    /// </summary>
    public Client()
    {
        Status = new ClientStatus();
        Manager = new Manager();
    }

    /// <summary>
    ///     Конструктор на случай если известны все атрибуты существующего в бд клиента 
    /// </summary>
    /// <param name="id">Идентификатор в бд</param>
    /// <param name="name">Имя клиента</param>
    /// <param name="clientStatus">Статус клиента</param>
    /// <param name="manager">Менеджер</param>
    /// <param name="products">Купленные товары</param>
    public Client(int id, string name, ClientStatus clientStatus, Manager manager, ICollection<Product> products) :
        this(id, name, clientStatus, manager)
    {
        Products = new EntityCollectionStore<Product>(products);
    }


    /// <summary>
    ///     Конструктор для на случай реально известных реальных атрибутов
    /// </summary>
    /// <param name="id">Идентификатор в бд</param>
    /// <param name="name">Имя клиента</param>
    /// <param name="clientStatus">Статус клиента</param>
    /// <param name="manager">Привязанный менеджер</param>
    public Client(int id, string name, ClientStatus clientStatus, Manager manager) : this(id, name, clientStatus)
    {
        Manager = manager;
    }


    /// <summary>
    ///     Конструктор для на случай реальных известных частичных атрибутов
    /// </summary>
    /// <param name="id">Идентификатор в бд</param>
    /// <param name="name">Имя клиента</param>
    /// <param name="clientStatus">Статус клиента</param>
    /// <param name="manager">Привязанный менеджер</param>
    public Client(int id, string name, ClientStatus clientStatus) : base(id, name)
    {
        Status = clientStatus;
    }

    #endregion

    #region Свойства и поля

    #region Status : статус/тип клиента

    private ClientStatus _status;

    /// <summary>
    ///     Статус клиента
    /// </summary>
    [Required]
    public ClientStatus Status
    {
        get => _status;
        set => Set(ref _status, value);
    }

    #endregion

    #region Manager : cвязаный менеджер

    private Manager _manager;

    /// <summary>
    ///     Связный менедже
    /// </summary>
    public Manager Manager
    {
        get => _manager;
        set => Set(ref _manager, value);
    }

    #endregion


    /// <summary>
    ///     Купленные товары
    /// </summary>
    public ICollection<Product> Products { get; set; } = new EntityCollectionStore<Product>();

    #endregion

    #region Методы

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

        return EntityCollectionServices.IsCollectionsEqualsNoDeep(Products, otherEntity.Products);
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

    protected override bool SubHaveErrors()
    {
        return Status.HasErrors || Manager.HasErrors;
    }

    #endregion
}