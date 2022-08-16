﻿using System.Collections.ObjectModel;
using ProjectMateTask.DAL.Entities.Base;
using ProjectMateTask.DAL.Services;
using ProjectMateTask.DAL.Stores;

namespace ProjectMateTask.DAL.Entities.Actors;

public sealed class Manager : NamedEntity
{
    #region Конструкторы

    public Manager()
    {
    }

    public Manager(int id, string name, ICollection<Client> clients) : base(id, name)
    {
        Clients = new EntityCollectionStore<Client>(clients);
    }

    public Manager(int id, string name) : base(id, name)
    {
    }

    #endregion
    public ICollection<Client> Clients { get; set; } = new EntityCollectionStore<Client>();
    
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
            new EntityCollectionStore<Client>(
                Clients.Select(item => item)
            ));
    }
}