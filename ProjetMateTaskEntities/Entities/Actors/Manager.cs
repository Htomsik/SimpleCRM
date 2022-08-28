using ProjetMateTaskEntities.Entities.Base;
using ProjetMateTaskEntities.Services;
using ProjetMateTaskEntities.Stores;

namespace ProjetMateTaskEntities.Entities.Actors;

/// <summary>
///     Существующие в бд менеджеры с NamedEntity типом
/// </summary>
public sealed class Manager : NamedEntity
{
    #region Свойства и поля

    /// <summary>
    ///     Связные клиенты (Клиенты, которых обслуживает данный менеджер)
    /// </summary>
    public ICollection<Client> Clients { get; set; } = new EntityCollectionStore<Client>();

    #endregion

    #region Конструкторы

    /// <summary>
    ///     Конструктор для создания нового менеджера без заранее известных атрибутов
    /// </summary>
    public Manager()
    {
    }
    
    /// <summary>
    ///     Конструктор для менеджера со всеми известными реальными атрибутами в бд (Обычно используется для копирования)
    /// </summary>
    /// <param name="id">Идентификатор в бд</param>
    /// <param name="name">Имя менеджера</param>
    /// <param name="clients">Связные клиенты</param>
    public Manager(int id, string name, ICollection<Client> clients) : base(id, name)
    {
        Clients = new EntityCollectionStore<Client>(clients);
    }
    
    #endregion

    #region Методы

    protected override bool Equals(IEntity other)
    {
        var otherEntity = other as Manager;

        if (otherEntity is null)
            throw new TypeAccessException(
                $"Неправильный тип данных, требуемый тип: {GetType()}, фактический тип: {other.GetType()}");

        if (!base.Equals(other)) return false;

        return EntityCollectionServices.IsCollectionsEqualsNoDeep(Clients, otherEntity.Clients);
    }

    public override object Clone()
    {
        return new Manager(Id,
            Name,
            new EntityCollectionStore<Client>(
                Clients.Select(item => item)
            ));
    }

    #endregion
}