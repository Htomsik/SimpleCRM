using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.CloseNavigationServices;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores.Base;
using ProjectMateTask.VMD.Base;
using ProjectMateTaskWpfTests.ServicesTests.NavigationServicesTests.Base;

namespace ProjectMateTaskWpfTests.ServicesTests.NavigationServicesTests.CloseNavigationServicesTests;

[TestClass]
public class BaseCloseNavigationServicesRealizeTests : BaseCloseNavigationServicesAbstractTest<BaseCloseNavigationServices<BaseVmd>,BaseVmd>
{
    protected override BaseCloseNavigationServices<BaseVmd> CreateSomeStore(
        IVmdNavigationStore<BaseVmd> vmdNavigationStore) => new(vmdNavigationStore);

}