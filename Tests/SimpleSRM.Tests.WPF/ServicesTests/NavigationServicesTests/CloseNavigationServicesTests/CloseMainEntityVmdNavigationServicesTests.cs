using SimpleSRM.Tests.WPF.ServicesTests.NavigationServicesTests.Base;
using SimpleSRM.WPF.Services.AppInfrastructure.NavigationServices.CloseNavigationServcies;
using SimpleSRM.WPF.Stores.AppInfrastructure.NavigationStores.Base;
using SimpleSRM.WPF.VMD.Pages.Entities.Base;

namespace SimpleSRM.Tests.WPF.ServicesTests.NavigationServicesTests.CloseNavigationServicesTests;

[TestClass]
public class CloseMainEntityVmdNavigationServicesTests : BaseCloseNavigationServicesAbstractTest<CloseMainEntityVmdNavigationServices,BaseEntityVmd>
{
    protected override CloseMainEntityVmdNavigationServices CreateSomeStore(
        IVmdNavigationStore<BaseEntityVmd> vmdNavigationStore) => new(vmdNavigationStore);

}