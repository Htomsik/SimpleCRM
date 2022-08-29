using ProjectMateTaskDalTests.Resources;
using ProjetMateTaskEntities.Entities.Base;

namespace ProjectMateTaskDalTests.EnitiesTests.Base;

public abstract class NamedEntityTests<TEntity> where TEntity : INamedEntity, new()
{
    /// <summary>
    ///     Одинаковы ли рандомный NamedEntity и его копия
    /// </summary>
    [TestMethod]
    public virtual void IsTwoRandomNamedEntityCopyEquals()
    {
        // Arrange
        var originalNameEntity = GlobalResources.GetRandomEntity<TEntity>();
        
        TEntity namedEntityCopy = (TEntity)originalNameEntity.Clone();

        //Act
        var originalResult = namedEntityCopy.Equals(originalNameEntity);

        var copyResult = originalNameEntity.Equals(namedEntityCopy);

        //Assert
        Assert.AreEqual(originalResult, copyResult);
    }
    
    /// <summary>
    ///     Проверяет правильность срабатывание HasErrors свойства по мере заполнения атрибутов
    /// </summary>
    [TestMethod]
    public virtual void INamedEntityHaveErrorsIsRight() 
    {
        //Arrange
        var namedEntity = new TEntity();
        
        //Act+Assert
        Assert.IsTrue(namedEntity.HasErrors);
        
        SpecifiedCheckInHaveErrors(namedEntity);
        
    }
    
    public virtual void SpecifiedCheckInHaveErrors(TEntity namedEntity)
    {
        namedEntity.Name = string.Concat(Enumerable.Repeat("S" , 151));
        
        Assert.IsTrue(namedEntity.HasErrors);

        namedEntity.Name = "SomeNamedEntity";
        
        Assert.IsFalse(namedEntity.HasErrors);
    }
   
}