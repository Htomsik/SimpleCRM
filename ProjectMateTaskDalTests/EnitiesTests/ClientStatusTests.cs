using System;
using ProjectMateTaskDalTests.Resources;
using ProjetMateTaskEntities.Entities.Types;

namespace ProjectMateTaskDalTests.EnitiesTests;

[TestClass]
public class ClientStatusTests
{
    [TestMethod]
    public void IsTwoRandomClientStatusesEquals()
    {
        // Arrange
        var rnd = new Random();
        
        var initializer = new EntitiesTestDataInitializer();
        
        ClientStatus randomEntity = initializer.ClientTypes[rnd.Next(0, EntitiesTestDataInitializer.TestClientTypesCount)];

        ClientStatus randomEntityCopy = (ClientStatus)randomEntity.Clone();
        
        //Act
        var originalResult = randomEntity.Equals(randomEntityCopy);

        var copyResult = randomEntityCopy.Equals(randomEntity);
        
        //Assert
        Assert.AreEqual(originalResult,copyResult);
    }
}