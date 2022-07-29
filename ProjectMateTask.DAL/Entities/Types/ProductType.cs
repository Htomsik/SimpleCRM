using ProjectMateTask.DAL.Entities.Actors;
using ProjectMateTask.DAL.Entities.Base;

namespace ProjectMateTask.DAL.Entities.Types;

public sealed class ProductType:NamedEntity
{
    public ICollection<Product> Products { get; set; }
}