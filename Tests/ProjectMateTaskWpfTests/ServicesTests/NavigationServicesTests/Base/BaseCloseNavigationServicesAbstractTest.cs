using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.CloseNavigationServices;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores.Base;
using ProjectMateTask.VMD.Base;

namespace ProjectMateTaskWpfTests.ServicesTests.NavigationServicesTests.Base;

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