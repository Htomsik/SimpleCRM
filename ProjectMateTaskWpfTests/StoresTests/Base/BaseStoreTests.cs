using ProjectMateTask.Stores.Base;

namespace ProjectMateTaskWpfTests.StoresTests.Base;

[TestClass]
public class BaseStoreTests<TStore,TValue> where TStore: IStore<TValue>, new() where TValue: class, new()
{
    /// <summary>
    ///     Срабатывает ли уведомитель при изменении значения
    /// </summary>
    [TestMethod]
    public void IsCurrentValueChangedNotify()
    { 
        //Arrange
        var someStore = new TStore();

        bool isCurrentValueChanged = false;
        
        //Act
        someStore.CurrentValueChanged += ()=> isCurrentValueChanged = true;

        someStore.CurrentValue = new TValue();
        
        //Assert
        Assert.IsTrue(isCurrentValueChanged);
        
    }
    
  
}