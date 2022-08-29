using System;
using ProjectMateTaskDalTests.Resources;
using ProjetMateTaskEntities.Entities.Actors;

namespace ProjectMateTaskDalTests.EnitiesTests;

[TestClass]
public class ClientTests
{
    [TestMethod]
    public void IsTwoRandomClientsCopyEquals()
    {
        // Arrange
        var rnd = new Random();
        
        Client randomEntity = GlobalResources.Initializer.TestClients[rnd.Next(0, EntitiesTestDataInitializer.TestClientsCount)];

        Client randomEntityCopy = (Client)randomEntity.Clone();
        
        //Act
        var originalResult = randomEntity.Equals(randomEntityCopy);

        var copyResult = randomEntityCopy.Equals(randomEntity);
        
        //Assert
        Assert.AreEqual(originalResult,copyResult);
    }
}