using SimpleSRM.Tests.WPF.ServicesTests.NavigationServicesTests.Base;
using SimpleSRM.WPF.Services.AppInfrastructure.NavigationServices.Base.NavigationServices;
using SimpleSRM.WPF.Stores.AppInfrastructure.NavigationStores.Base;
using SimpleSRM.WPF.VMD.Base;

namespace SimpleSRM.Tests.WPF.ServicesTests.NavigationServicesTests.NavigationServicesTests;

[TestClass]
public class BaseStoreNavigationServicesAbstractRealizeTests : BaseStoreNavigationServicesAbstractTests<BaseStoreNavigationServices<BaseVmd>,BaseVmd>
{
    protected override BaseStoreNavigationServices<BaseVmd> CreateSomeStore(
        IVmdNavigationStore<BaseVmd> vmdNavigationStore, Func<BaseVmd> createVmd) =>
        new (vmdNavigationStore, createVmd);

}