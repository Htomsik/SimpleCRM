using SimpleSRM.WPF.Services.AppInfrastructure.NavigationServices.Base.NavigationServices;
using SimpleSRM.WPF.Stores.AppInfrastructure.NavigationStores.Base;
using SimpleSRM.WPF.VMD.Base;

namespace SimpleSRM.Tests.WPF.ServicesTests.NavigationServicesTests.Base;

public abstract class BaseStoreNavigationServicesAbstractTests<TStoreNavigationServices,TVmd> where TStoreNavigationServices :BaseStoreNavigationServices<TVmd> where TVmd : BaseVmd, new()
{
    /// <summary>
    ///     Проверка на то, изменяется ли Store при взимодействии с Service
    /// </summary>
    [TestMethod]
    public void IsStoreNavigationServicesNavigate()
    {
        //Arrange
        var someLocalNavigationStore = new BaseVmdNavigationStore<TVmd>();

        var someNewVmd = new TVmd();

        var someNavigationServices = CreateSomeStore(someLocalNavigationStore, ()=> someNewVmd);
        //Act
        someNavigationServices.Navigate();
        
        //Assert
        Assert.AreEqual(someNewVmd,someLocalNavigationStore.CurrentValue);
    }

    protected abstract TStoreNavigationServices CreateSomeStore(IVmdNavigationStore<TVmd> vmdNavigationStore,
        Func<TVmd> createVmd);
    
    /// <summary>
    ///     Проверка на то, обнуляется ли Store при выове Close метода
    /// </summary>
    [TestMethod]
    public void IsStoreNavigationServicesClose()
    {
        //Arrange
        var someLocalNavigationStore = new BaseVmdNavigationStore<TVmd>();

        var someNewVmd = new TVmd();

        var someNavigationServices = CreateSomeStore(someLocalNavigationStore, ()=> someNewVmd);
        
        //Act + Assert
        someNavigationServices.Navigate();
        
        Assert.AreEqual(someNewVmd,someLocalNavigationStore.CurrentValue);
        
        someNavigationServices.Close();
        
        Assert.IsNull(someLocalNavigationStore.CurrentValue);
        
    }
}