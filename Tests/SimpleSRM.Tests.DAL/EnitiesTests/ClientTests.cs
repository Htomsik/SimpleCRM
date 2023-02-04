using SimpleSRM.Models.Entities.Actors;
using SimpleSRM.Models.Entities.Types;
using SimpleSRM.Tests.DAL.EnitiesTests.Base;
using SimpleSRM.Tests.DAL.Resources;

namespace SimpleSRM.Tests.DAL.EnitiesTests;

[TestClass]
public class ClientTests : NamedEntityTests<Client>
{
    public override void SpecifiedCheckInHaveErrors(Client namedEntity)
    {
        namedEntity.Name = string.Concat(Enumerable.Repeat("S", 151));

        Assert.IsTrue(namedEntity.HasErrors);

        namedEntity.Name = "SomeNamedEntity";

        Assert.IsTrue(namedEntity.HasErrors);

        namedEntity.Manager = GlobalResources.GetRandomEntity<Manager>();

        Assert.IsTrue(namedEntity.HasErrors);

        namedEntity.Status = GlobalResources.GetRandomEntity<ClientStatus>();

        Assert.IsFalse(namedEntity.HasErrors);
    }
}