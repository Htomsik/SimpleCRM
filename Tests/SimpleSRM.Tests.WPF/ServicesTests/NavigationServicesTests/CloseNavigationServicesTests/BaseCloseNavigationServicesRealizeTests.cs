using SimpleSRM.Tests.WPF.ServicesTests.NavigationServicesTests.Base;
using SimpleSRM.WPF.Services.AppInfrastructure.NavigationServices.Base.CloseNavigationServices;
using SimpleSRM.WPF.Stores.AppInfrastructure.NavigationStores.Base;
using SimpleSRM.WPF.VMD.Base;

namespace SimpleSRM.Tests.WPF.ServicesTests.NavigationServicesTests.CloseNavigationServicesTests;

[TestClass]
public class BaseCloseNavigationServicesRealizeTests : BaseCloseNavigationServicesAbstractTest<BaseCloseNavigationServices<BaseVmd>,BaseVmd>
{
    protected override BaseCloseNavigationServices<BaseVmd> CreateSomeStore(
        IVmdNavigationStore<BaseVmd> vmdNavigationStore) => new(vmdNavigationStore);

}