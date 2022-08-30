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

        var namedEntityCopy = (TEntity)originalNameEntity.Clone();

        //Act
        var originalResult = namedEntityCopy.Equals(originalNameEntity);

        var copyResult = originalNameEntity.Equals(namedEntityCopy);

        //Assert
        Assert.AreEqual(originalResult, copyResult);
    }

    /// <summary>
    ///     Проверка правильности срабатывания HasErrors свойства по мере заполнения атрибутов (для всех NamedEntity одинаковая
    ///     часть)
    /// </summary>
    [TestMethod]
    public void INamedEntityHaveErrorsIsRight()
    {
        //Arrange
        var namedEntity = new TEntity();

        //Act+Assert
        Assert.IsTrue(namedEntity.HasErrors);

        SpecifiedCheckInHaveErrors(namedEntity);
    }

    /// <summary>
    ///     Проверка правильность срабатывания HasErrors свойства по мере заполнения атрибутов (Индивидуальня часть для разных
    ///     NamedEntity)
    /// </summary>
    /// <param name="namedEntity">Проверяемый NamedEntity</param>
    public virtual void SpecifiedCheckInHaveErrors(TEntity namedEntity)
    {
        namedEntity.Name = string.Concat(Enumerable.Repeat("S", 151));

        Assert.IsTrue(namedEntity.HasErrors);

        namedEntity.Name = "SomeNamedEntity";

        Assert.IsFalse(namedEntity.HasErrors);
    }
}