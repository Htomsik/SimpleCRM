using System.ComponentModel.DataAnnotations;
using ProjectMateTask.DAL.Entities.Base;
using ProjectMateTask.DAL.Entities.Types;

namespace ProjectMateTask.DAL.Entities.Actors;

public sealed class Product:NamedEntity
{
    [Required]
    public ProductType Type { get; set; }

    public ICollection<Client> Clients { get; set; }
    
}