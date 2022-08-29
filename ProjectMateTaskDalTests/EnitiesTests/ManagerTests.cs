using ProjectMateTaskDalTests.Resources;
using ProjetMateTaskEntities.Entities.Actors;

namespace ProjectMateTaskDalTests.EnitiesTests;

[TestClass]
public class ManagerTests
{
    [TestMethod]
    public void IsTwoRandomManagersEquals()
    {
     
        // Arrange
        var rnd = new Random();
        
        var initializer = new EntitiesTestDataInitializer();
        
        Manager randomEntity = initializer.TestManagers[rnd.Next(0, EntitiesTestDataInitializer.TestManagersCount)];

        Manager randomEntityCopy = (Manager)randomEntity.Clone();
        
        //Act
        var originalResult = randomEntity.Equals(randomEntityCopy);

        var copyResult = randomEntityCopy.Equals(randomEntity);
        
        //Assert
        Assert.AreEqual(originalResult,copyResult);
    }
}