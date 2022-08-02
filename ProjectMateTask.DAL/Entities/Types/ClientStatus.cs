using System.Collections.ObjectModel;
using ProjectMateTask.DAL.Entities.Actors;
using ProjectMateTask.DAL.Entities.Base;

namespace ProjectMateTask.DAL.Entities.Types;

public sealed class ClientStatus : NamedEntity
{
    public ICollection<Client> Clients { get; set; }
    
    
    protected override bool Equals(IEntity other)
    {
        
        var otherProductEntity = other as ClientStatus;

        if (otherProductEntity is null )
        {
            throw new TypeAccessException($"Неправильный тип данных, требуемый тип: {this.GetType()}, фактический тип: {other.GetType()}");
        }
        
        if (!Clients.Except(otherProductEntity.Clients).Any())
            return true;
        return false;
    }
    
    public ClientStatus(){}

    public ClientStatus(int id,string name,ICollection<Client> clients)
    {
        Id = id;
        Name = name;
        Clients = clients;
    }
    
    public override object Clone() =>
        new ClientStatus(this.Id,
            this.Name,
            new ObservableCollection<Client>(
                Clients.Select(item => item).ToArray()
            ));
}