using System.Collections.ObjectModel;
using ProjectMateTask.DAL.Entities.Base;
using ProjectMateTask.DAL.Entities.Services;

namespace ProjectMateTask.DAL.Entities.Actors;

public sealed class Manager : NamedEntity
{
    public Manager()
    {
    }

    public Manager(int id, string name, ICollection<Client> clients) : base(id, name)
    {
        Clients = clients;
    }

    public Manager(int id, string name) : base(id, name)
    {
    }

    public ICollection<Client> Clients { get; set; } = new ObservableCollection<Client>();


    protected override bool Equals(IEntity other)
    {
        var otherEntity = other as Manager;

        if (otherEntity is null)
            throw new TypeAccessException(
                $"Неправильный тип данных, требуемый тип: {GetType()}, фактический тип: {other.GetType()}");

        if (!base.Equals(other)) return false;

        return EntityServices<Client>.IsCollectionsEqualsNoDeep(Clients, otherEntity.Clients);
    }


    public override object Clone()
    {
        return new Manager(Id,
            Name,
            new ObservableCollection<Client>(
                Clients.Select(item => item).ToArray()
            ));
    }
}