using System.ComponentModel.DataAnnotations;
using ProjetMateTaskEntities.Entities.Base;
using ProjetMateTaskEntities.Entities.Types;
using ProjetMateTaskEntities.Services;
using ProjetMateTaskEntities.Stores;

namespace ProjetMateTaskEntities.Entities.Actors;

/// <summary>
///     Существующие в бд продукты с NamedEntity типом
/// </summary>
public sealed class Product : NamedEntity
{
    
    #region Конструкторы

    /// <summary>
    ///     Конструктор для создания нового продукта без заранее известных атрибутов
    /// </summary>
    public Product()
    {
        Type = new ProductType();
    }

    /// <summary>
    ///     Конструктор на случай если известны все атрибуты существующего в бд продукта (Обычно используется для копирования)
    /// </summary>
    public Product(int id, string name, ProductType productType, ICollection<Client> clients) : base(id, name)
    {
        Type = productType;
        Clients = new EntityCollectionStore<Client>(clients);
    }

    /// <summary>
    ///     Конструктор на случай если частично известны реальные атрибуты существующего в бд продукта
    /// </summary>
    /// <param name="id">Идентификатор в бд</param>
    /// <param name="name">Наименование</param>
    /// <param name="productType">Тип продукта</param>
    public Product(int id, string name, ProductType productType) : base(id, name)
    {
        Type = productType;
    }

    #endregion

    #region Свойства и поля

    #region Type : тип продукта

    private ProductType _type;

    /// <summary>
    ///     Тип продукта
    /// </summary>
    [Required]
    public ProductType Type
    {
        get => _type;
        set => Set(ref _type, value);
    }

    #endregion
    
    /// <summary>
    ///     Клиенты, купившие данный продукты
    /// </summary>
    public ICollection<Client> Clients { get; set; } = new EntityCollectionStore<Client>();

    #endregion

    #region Методы

    protected override bool Equals(IEntity other)
    {
        var otherEntity = other as Product;

        if (otherEntity is null)
            throw new TypeAccessException(
                $"Неправильный тип данных, требуемый тип: {GetType()}, фактический тип: {other.GetType()}");

        if (!base.Equals(other) || !Type.Equals(otherEntity.Type)) return false;

        return EntityCollectionServices.IsCollectionsEqualsNoDeep(Clients, otherEntity.Clients);
    }

    protected override bool SubHasErrors()
    {
        return Type.HasErrors;
    }

    public override object Clone()
    {
        return new Product(Id,
            Name,
            Type,
            new EntityCollectionStore<Client>(
                Clients.Select(item => item)
            ));
    }

    #endregion
}