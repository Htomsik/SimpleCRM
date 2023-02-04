using SimpleSRM.Models.Entities.Actors;
using SimpleSRM.Models.Entities.Base;
using SimpleSRM.Models.Services;
using SimpleSRM.Models.Stores;

namespace SimpleSRM.Models.Entities.Types;

/// <summary>
///     Существующие в бд типы подуктов с NamedEntity типом
/// </summary>
public sealed class ProductType : NamedEntity
{
    #region Конструкторы
    
    /// <summary>
    ///     Конструктор для создания нового типа продуктов без заранее известных атрибутов
    /// </summary>
    public ProductType()
    {
    }
    
    /// <summary>
    ///     Конструктор для создания нового типа продуктов с заранее частично известными атрибутами
    /// </summary>
    /// <param name="name">Наименование</param>
    public ProductType(string name):base(name)
    {
    }

    /// <summary>
    ///       Конструктор на случай если известны все атрибуты существующего в бд типа продуктов 
    /// </summary>
    /// <param name="id">Идентификатор в бд</param>
    /// <param name="name">Наименование</param>
    /// <param name="products">Продукты с данным статусом</param>
    public ProductType(int id, string name, ICollection<Product> products)
    {
        Id = id;
        Name = name;
        Products = new EntityCollectionStore<Product>(products);
    }

    /// <summary>
    ///      Конструктор с частично известными атрибутами в бд
    /// </summary>
    /// <param name="name">Наименование</param>
    public ProductType(int id, string name) : base(id, name)
    {
    }

    #endregion

    #region Свойства и поля

    /// <summary>
    ///     Продукты с данным типом
    /// </summary>
    public ICollection<Product> Products { get; set; } = new EntityCollectionStore<Product>();

    #endregion

    #region Методы

    protected override bool Equals(IEntity other)
    {
        var otherEntity = other as ProductType;

        if (otherEntity is null)
            throw new TypeAccessException(
                $"Неправильный тип данных, требуемый тип: {GetType()}, фактический тип: {other.GetType()}");

        if (!base.Equals(other)) return false;

        return EntityCollectionServices.IsCollectionsEqualsNoDeep(Products, otherEntity.Products);
    }
    
    public override object Clone()
    {
        return new ProductType(Id,
            Name,
            new EntityCollectionStore<Product>(
                Products.Select(item => item).ToArray()
            ));
    }

    #endregion
    
}