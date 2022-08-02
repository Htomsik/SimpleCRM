using System.Collections.ObjectModel;
using ProjectMateTask.DAL.Entities.Base;

namespace ProjectMateTask.DAL.Entities.Actors;

public sealed class Manager : NamedEntity
{
    public ICollection<Client> Clients { get; set; } = new ObservableCollection<Client>();
    
    
    protected override bool Equals(IEntity other)
    {
        var otherEntity = other as Manager;

        if (otherEntity is null )
        {
            throw new TypeAccessException($"Неправильный тип данных, требуемый тип: {this.GetType()}, фактический тип: {other.GetType()}");
        }
        
        
        if (!base.Equals(other) || Clients.Count != otherEntity.Clients.Count) return false;
            
        return Clients.Any(origin => otherEntity.Clients.Any(copy => copy.Id != origin.Id));
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