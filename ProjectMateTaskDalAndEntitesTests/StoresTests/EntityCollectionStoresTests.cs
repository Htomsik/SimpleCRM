using System.Collections.ObjectModel;
using ProjectMateTaskDalTests.Resources;
using ProjetMateTaskEntities.Entities.Actors;
using ProjetMateTaskEntities.Entities.Base;
using ProjetMateTaskEntities.Stores;

namespace ProjectMateTaskDalTests.StoresTests;

[TestClass]
public class EntityCollectionStoresTests
{
    /// <summary>
    ///    Не может ли EntityCollectionStore содержать дубликаты по Id 
    /// </summary>
    [TestMethod]
    public void IsCantAddIdCopiesInCollection()
    {
        //Arrange
        var someEntity = new NamedEntity(0, "SomeEntity1");

        var entityWithSomeId = new NamedEntity(0, "SomeEntity2");

        var namedEntityCollection = new EntityCollectionStore<NamedEntity>();

        //Act
        namedEntityCollection.Add(someEntity);

        namedEntityCollection.Add(entityWithSomeId);

        //Act+Assert
        Assert.AreEqual(false, namedEntityCollection.Contains(entityWithSomeId));

    }

    /// <summary>
    ///     Не может ли коллекция содержать дубликаты по id когда она создаётся из другой коллеции
    /// </summary>
    [TestMethod]
    public void IsCollectionCantContainIdCopiesWhenCreateByOtherCollection()
    {
       //Arrange
       var someEntityArray = new NamedEntity[]
       {
           new (0,"SomeEntity"),
           new (0,"SomeEntity1"),
           new (1,"SomeEntity2"),
           new (2,"SomeEntity3"),
       };
       
       var someEntityLists = new List<NamedEntity>(someEntityArray);
       
       var someEntityCollection = new ObservableCollection<NamedEntity>(someEntityArray);
       
       //Act+Assert
       Assert.ThrowsException<ArgumentException>(() =>
           new EntityCollectionStore<NamedEntity>(someEntityArray));
       
       Assert.ThrowsException<ArgumentException>(() =>
           new EntityCollectionStore<NamedEntity>(someEntityLists));
       
       Assert.ThrowsException<ArgumentException>(() =>
           new EntityCollectionStore<NamedEntity>(someEntityCollection));
       
    }


    /// <summary>
    ///     Идентична ли копия коллекции оригиналу
    /// </summary>
    [TestMethod]
    public void IsCollectionWithCopyEquals()
    {
        //Arrange
        var someEntityCollections = new EntityCollectionStore<Client>(GlobalResources.Initializer.TestClients);

        Client[] copySomeEntityArray = new Client[someEntityCollections.Count];

        //Act
        someEntityCollections.CopyTo(copySomeEntityArray, 0);

        var copySomeEntityCollections = new EntityCollectionStore<Client>(copySomeEntityArray);

        //Act+Assert
        Assert.AreEqual(true, someEntityCollections.Equals(copySomeEntityCollections));
    }
}

    