using SimpleSRM.Tests.WPF.ServicesTests.NavigationServicesTests.Base;
using SimpleSRM.WPF.Services.AppInfrastructure.NavigationServices.NavigationServices;
using SimpleSRM.WPF.Stores.AppInfrastructure.NavigationStores.Base;
using SimpleSRM.WPF.VMD.Pages.AdditionalPagesVmds.Base;

namespace SimpleSRM.Tests.WPF.ServicesTests.NavigationServicesTests.NavigationServicesTests;

[TestClass]
public class AdditionalPageStoreNavigationServiceTests : BaseStoreNavigationServicesAbstractTests<AdditionalPageStoreNavigationService,BaseAdditionalVmd>
{
    protected override AdditionalPageStoreNavigationService CreateSomeStore(
        IVmdNavigationStore<BaseAdditionalVmd> vmdNavigationStore, Func<BaseAdditionalVmd> createVmd) =>
        new(vmdNavigationStore, createVmd);

}