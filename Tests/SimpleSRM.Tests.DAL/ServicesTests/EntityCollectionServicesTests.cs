using SimpleSRM.Models.Entities.Base;
using SimpleSRM.Models.Services;

namespace SimpleSRM.Tests.DAL.ServicesTests;

[TestClass]
public class EntityCollectionServicesTests
{
    /// <summary>
    ///     Проверка на соотвествие двух коллекций
    /// </summary>
    [TestMethod]
    public void IsCollectionsEqualsNoDeep()
    {
        //Arrange
        var someEntityLists = new List<NamedEntity>
        {
            new(0, "SomeEntity"),
            new(1, "SomeEntity2"),
            new(2, "SomeEntity3")
        };

        var someEntityListCopy = new List<NamedEntity>
        {
            new(0, "SomeEntity"),
            new(1, "SomeEntity2"),
            new(2, "SomeEntity3")
        };

        var someEntityOtherList = new List<NamedEntity>
        {
            new(0, "SomeEntity"),
            new(1, "SomeEntity2"),
            new(15, "SomeEntity3")
        };

        //Act+Assert
        Assert.IsTrue(EntityCollectionServices.IsCollectionsEqualsNoDeep(someEntityLists, someEntityListCopy));
        Assert.IsFalse(EntityCollectionServices.IsCollectionsEqualsNoDeep(someEntityLists, someEntityOtherList));
    }

    /// <summary>
    ///     Проверка на то, есть ли в коллекции дубликаты
    /// </summary>
    [TestMethod]
    public void IsCollectionHaveDuplicateByIds()
    {
        //Arrange
        var someEntityArrayWithDuplicates = new NamedEntity[]
        {
            new(0, "SomeEntity"),
            new(0, "SomeEntity1"),
            new(1, "SomeEntity2"),
            new(2, "SomeEntity3")
        };

        var someEntityArrayWithoutDuplicates = new NamedEntity[]
        {
            new(0, "SomeEntity"),
            new(1, "SomeEntity1"),
            new(2, "SomeEntity2")
        };


        //Act+Assert
        Assert.IsTrue(EntityCollectionServices.IsCollectionHaveDuplicateByIds(someEntityArrayWithDuplicates));
        Assert.IsFalse(EntityCollectionServices.IsCollectionHaveDuplicateByIds(someEntityArrayWithoutDuplicates));
    }

    /// <summary>
    /// </summary>
    [TestMethod]
    public void IsFindElemByIdInCollectionAndOriginalSame()
    {
        //Arrange
        var someEntityArray = new NamedEntity[]
        {
            new(0, "SomeEntity"),
            new(0, "SomeEntity1"),
            new(1, "SomeEntity2"),
            new(2, "SomeEntity3")
        };

        //Act+Assert
        Assert.AreEqual(someEntityArray[0], EntityCollectionServices.FindElemByIdInCollection(someEntityArray, 0));
        Assert.IsNull(EntityCollectionServices.FindElemByIdInCollection(someEntityArray, 111));
    }
}