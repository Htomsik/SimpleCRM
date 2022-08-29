using System;
using ProjectMateTaskDalTests.Resources;
using ProjetMateTaskEntities.Entities.Types;

namespace ProjectMateTaskDalTests.EnitiesTests;

[TestClass]
public class ProductTypeTests
{
    [TestMethod]
    public void IsTwoRandomProductTypesCopyEquals()
    {
        // Arrange
        var rnd = new Random();
        
        ProductType randomEntity = GlobalResources.Initializer.ProductTypes[rnd.Next(0, EntitiesTestDataInitializer.TestProductTypesCount)];

        ProductType randomEntityCopy = (ProductType)randomEntity.Clone();
        
        //Act
        var originalResult = randomEntity.Equals(randomEntityCopy);

        var copyResult = randomEntityCopy.Equals(randomEntity);
        
        //Assert
        Assert.AreEqual(originalResult,copyResult);
    }
}