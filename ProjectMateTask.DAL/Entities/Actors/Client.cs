using System.ComponentModel.DataAnnotations;
using ProjectMateTask.DAL.Entities.Base;
using ProjectMateTask.DAL.Entities.Types;

namespace ProjectMateTask.DAL.Entities.Actors;

public sealed class Client: NamedEntity
{
    [Required]
    public ClientStatus Status { get; set; }

    public Manager Manager { get; set; }

    public ICollection<Product> Products { get; set; }

   
}