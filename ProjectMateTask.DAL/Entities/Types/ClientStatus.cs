using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using ProjectMateTask.DAL.Entities.Actors;
using ProjectMateTask.DAL.Entities.Base;
using ProjectMateTask.DAL.Services;
using ProjectMateTask.DAL.Stores;

namespace ProjectMateTask.DAL.Entities.Types;

public sealed class ClientStatus : NamedEntity
{
    #region Конструкторы

    public ClientStatus()
    {
    }

    public ClientStatus(int id, string name, ICollection<Client> clients) : base(id, name)
    {
        Clients = clients;
    }

    public ClientStatus(int id, string name) : base(id, name)
    {
    }

    #endregion
    
    public ICollection<Client> Clients { get; set; } = new EntityCollectionStore<Client>();

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
}