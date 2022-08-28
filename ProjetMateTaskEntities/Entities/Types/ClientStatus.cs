using ProjetMateTaskEntities.Entities.Actors;
using ProjetMateTaskEntities.Entities.Base;
using ProjetMateTaskEntities.Services;
using ProjetMateTaskEntities.Stores;

namespace ProjetMateTaskEntities.Entities.Types;

/// <summary>
///     Существующие в бд статусы клиентов с NamedEntity типом
/// </summary>
public sealed class ClientStatus : NamedEntity
{
    #region Конструкторы

    /// <summary>
    ///     Конструктор для создания нового клиента без заранее известных атрибутов
    /// </summary>
    public ClientStatus()
    {
    }

    /// <summary>
    ///      Конструктор на случай если известны все атрибуты существующего в бд статуса клиентов 
    /// </summary>
    /// <param name="id">Идентификатор в бд</param>
    /// <param name="name">Наименование</param>
    /// <param name="clients">Список клиентов с данным статусом</param>
    public ClientStatus(int id, string name, ICollection<Client> clients) : base(id, name)
    {
        Clients = clients;
    }

    /// <summary>
    ///     Конструктор с частично известными атрибутами в бд
    /// </summary>
    /// <param name="id">Идентификатор в бд</param>
    /// <param name="name">Наименование</param>
    public ClientStatus(int id, string name) : base(id, name)
    {
    }
    
    /// <summary>
    ///     Конструктор для создания нового статуса для клиентов с заранее частично известными атрибутами
    /// </summary>
    /// <param name="name">Наименование</param>
    public ClientStatus(string name) : base(name)
    {
    }

    #endregion

    #region Свойства и поля
    
    /// <summary>
    ///     Клиенты с данным статусом
    /// </summary>
    public ICollection<Client> Clients { get; set; } = new EntityCollectionStore<Client>();
    
    #endregion
    
    #region Методы

    protected override bool Equals(IEntity other)
    {
        var otherEntity = other as ClientStatus;

        if (otherEntity is null)
            throw new TypeAccessException(
                $"Неправильный тип данных, требуемый тип: {GetType()}, фактический тип: {other.GetType()}");

        if (!base.Equals(other)) return false;

        return EntityServices<Client>.IsCollectionsEqualsNoDeep(Clients, otherEntity.Clients);
    }
    
    public override object Clone()
    {
        return new ClientStatus(Id,
            Name,
            new EntityCollectionStore<Client>(
                Clients.Select(item => item).ToArray()
            ));
    }

    #endregion
  
}