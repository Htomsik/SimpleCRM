using ProjectMateTaskDalTests.Resources;
using ProjetMateTaskEntities.Entities.Types;

namespace ProjectMateTaskDalTests.EnitiesTests;

[TestClass]
public class ProductTypeTests
{
    [TestMethod]
    public void IsTwoRandomProductTypesEquals()
    {
        // Arrange
        var rnd = new Random();
        
        var initializer = new EntitiesTestDataInitializer();
        
        ProductType randomEntity = initializer.ProductTypes[rnd.Next(0, EntitiesTestDataInitializer.TestProductTypesCount)];

        ProductType randomEntityCopy = (ProductType)randomEntity.Clone();
        
        //Act
        var originalResult = randomEntity.Equals(randomEntityCopy);

        var copyResult = randomEntityCopy.Equals(randomEntity);
        
        //Assert
        Assert.AreEqual(originalResult,copyResult);
    }
}