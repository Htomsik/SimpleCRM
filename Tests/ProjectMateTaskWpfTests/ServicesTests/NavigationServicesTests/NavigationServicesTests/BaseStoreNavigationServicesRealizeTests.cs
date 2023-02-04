using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.NavigationServices;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores.Base;
using ProjectMateTask.VMD.Base;
using ProjectMateTaskWpfTests.ServicesTests.NavigationServicesTests.Base;

namespace ProjectMateTaskWpfTests.ServicesTests.NavigationServicesTests.NavigationServicesTests;

[TestClass]
public class BaseStoreNavigationServicesAbstractRealizeTests : BaseStoreNavigationServicesAbstractTests<BaseStoreNavigationServices<BaseVmd>,BaseVmd>
{
    protected override BaseStoreNavigationServices<BaseVmd> CreateSomeStore(
        IVmdNavigationStore<BaseVmd> vmdNavigationStore, Func<BaseVmd> createVmd) =>
        new (vmdNavigationStore, createVmd);

}