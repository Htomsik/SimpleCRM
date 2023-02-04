using SimpleSRM.Tests.WPF.ServicesTests.NavigationServicesTests.Base;
using SimpleSRM.WPF.Services.AppInfrastructure.NavigationServices.CloseNavigationServcies;
using SimpleSRM.WPF.Stores.AppInfrastructure.NavigationStores.Base;
using SimpleSRM.WPF.VMD.Pages.AdditionalPagesVmds.Base;

namespace SimpleSRM.Tests.WPF.ServicesTests.NavigationServicesTests.CloseNavigationServicesTests;

[TestClass]
public class CloseAdditionalPageNavigationServicesTests : BaseCloseNavigationServicesAbstractTest<CloseAdditionalPageNavigationServices,BaseAdditionalVmd>
{
    protected override CloseAdditionalPageNavigationServices CreateSomeStore(
        IVmdNavigationStore<BaseAdditionalVmd> vmdNavigationStore) => new(vmdNavigationStore);

}