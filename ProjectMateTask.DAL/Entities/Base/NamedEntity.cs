using System.ComponentModel.DataAnnotations;

namespace ProjectMateTask.DAL.Entities.Base;

public abstract class NamedEntity:Entity
{
    [Required]
    public string Name { get; set; }
}