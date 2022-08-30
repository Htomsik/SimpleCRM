using ProjectMateTaskDalTests.EnitiesTests.Base;
using ProjectMateTaskDalTests.Resources;
using ProjetMateTaskEntities.Entities.Actors;
using ProjetMateTaskEntities.Entities.Types;

namespace ProjectMateTaskDalTests.EnitiesTests;

[TestClass]
public class ProductTests : NamedEntityTests<Product>
{
    public override void SpecifiedCheckInHaveErrors(Product namedEntity)
    {
        namedEntity.Name = string.Concat(Enumerable.Repeat("S", 151));

        Assert.IsTrue(namedEntity.HasErrors);

        namedEntity.Name = "SomeNamedEntity";

        Assert.IsTrue(namedEntity.HasErrors);

        namedEntity.Type = GlobalResources.GetRandomEntity<ProductType>();

        Assert.IsFalse(namedEntity.HasErrors);
    }
}