using ProjectMateTask.DAL.Entities.Actors;
using ProjectMateTask.DAL.Entities.Base;

namespace ProjectMateTask.DAL.Entities.Types;

public sealed class ClientStatus : NamedEntity
{
    public ICollection<Client> Clients { get; set; }
}