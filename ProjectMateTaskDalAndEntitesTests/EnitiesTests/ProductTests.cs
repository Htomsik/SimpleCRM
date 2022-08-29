using System;
using ProjectMateTaskDalTests.Resources;
using ProjetMateTaskEntities.Entities.Actors;

namespace ProjectMateTaskDalTests.EnitiesTests;

[TestClass]
public class ProductTests
{
    [TestMethod]
    public void IsTwoRandomProductsCopyEquals()
    {
     
        // Arrange
        var rnd = new Random();
        
        Product randomEntity = GlobalResources.Initializer.TestProducts[rnd.Next(0, EntitiesTestDataInitializer.TestProductsCount)];

        Product randomEntityCopy = (Product)randomEntity.Clone();
        
        //Act
        var originalResult = randomEntity.Equals(randomEntityCopy);

        var copyResult = randomEntityCopy.Equals(randomEntity);
        
        //Assert
        Assert.AreEqual(originalResult,copyResult);
    }
}