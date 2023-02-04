using SimpleSRM.Models.Entities.Actors;
using SimpleSRM.Models.Entities.Types;
using SimpleSRM.Tests.DAL.EnitiesTests.Base;
using SimpleSRM.Tests.DAL.Resources;

namespace SimpleSRM.Tests.DAL.EnitiesTests;

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