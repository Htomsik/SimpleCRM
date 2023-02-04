using SimpleSRM.WPF.Services.AppInfrastructure.NavigationServices.Base.CloseNavigationServices;
using SimpleSRM.WPF.Stores.AppInfrastructure.NavigationStores.Base;
using SimpleSRM.WPF.VMD.Base;

namespace SimpleSRM.Tests.WPF.ServicesTests.NavigationServicesTests.Base;

public abstract class BaseCloseNavigationServicesAbstractTest<TCloseNavigationServices,TVmd> where TCloseNavigationServices : BaseCloseNavigationServices<TVmd>  where TVmd : BaseVmd, new()
{
    /// <summary>
    ///     Проверка на то, изменяется ли Store при взимодействии с Service
    /// </summary>
    [TestMethod]
    public void IsCloseNavigationServicesNavigate()
    {
        //Arrange
        var someLocalNavigationStore = new BaseVmdNavigationStore<TVmd>();
        
        var someCloseNavigationServices = CreateSomeStore(someLocalNavigationStore);
        
        //Act + Assert
        someLocalNavigationStore.CurrentValue = new TVmd();;
        
        Assert.IsNotNull(someLocalNavigationStore.CurrentValue);
        
        someCloseNavigationServices.Close();
        
        Assert.IsNull(someLocalNavigationStore.CurrentValue);
    }

    protected abstract TCloseNavigationServices CreateSomeStore(IVmdNavigationStore<TVmd> vmdNavigationStore);
}