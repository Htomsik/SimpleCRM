using ProjectMateTask.DAL.Entities.Types;
using ProjectMateTaskDalTests.Resources;

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
        
        ProductType randomEntity = initializer.ProductTypes[rnd.Next(0, EntitiesTestDataInitializer.TestProductTypesCount)];

        ClientStatus randomEntityCopy = (ClientStatus)randomEntity.Clone();
        
        //Act
        var originalResult = randomEntity.Equals(randomEntityCopy);

        var copyResult = randomEntityCopy.Equals(randomEntity);
        
        //Assert
        Assert.AreEqual(originalResult,copyResult);
    }
}