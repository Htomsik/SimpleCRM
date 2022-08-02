using System.Collections.ObjectModel;
using ProjectMateTask.DAL.Entities.Base;

namespace ProjectMateTask.DAL.Entities.Actors;

public sealed class Manager : NamedEntity
{
    public ICollection<Client> Clients { get; set; } = new ObservableCollection<Client>();
    
    
    protected override bool Equals(IEntity other)
    {
        var otherProductEntity = other as Manager;

        if (otherProductEntity is null )
        {
            throw new TypeAccessException($"Неправильный тип данных, требуемый тип: {this.GetType()}, фактический тип: {other.GetType()}");
        }
        
        if (!Clients.Except(otherProductEntity.Clients).Any())
            return true;
        return false;
    }
    
    
    public Manager(){}

    public Manager(int id, string name, ICollection<Client> clients)
    {
        Id = id;
        
        Name = name;
        
        Clients = clients;
    }
    
    
    public override object Clone() =>
        new Manager(this.Id,
            this.Name,
            new ObservableCollection<Client>(
                Clients.Select(item => item).ToArray()
            ));

}