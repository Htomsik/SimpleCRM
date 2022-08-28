using ProjectMateTaskDalTests.Resources;
using ProjetMateTaskEntities.Entities.Actors;

namespace ProjectMateTaskDalTests.EnitiesTests;

[TestClass]
public class ProductTests
{
    [TestMethod]
    public void IsTwoRandomProductsEquals()
    {
     
        // Arrange
        var rnd = new Random();
        
        var initializer = new EntitiesTestDataInitializer();
        
        Product randomEntity = initializer.TestProducts[rnd.Next(0, EntitiesTestDataInitializer.TestProductsCount)];

        Product randomEntityCopy = (Product)randomEntity.Clone();
        
        //Act
        var originalResult = randomEntity.Equals(randomEntityCopy);

        var copyResult = randomEntityCopy.Equals(randomEntity);
        
        //Assert
        Assert.AreEqual(originalResult,copyResult);
    }
}