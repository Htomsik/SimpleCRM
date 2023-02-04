using ProjectMateTask.Services.AppInfrastructure.NavigationServices.NavigationServices;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores.Base;
using ProjectMateTask.VMD.Pages.AdditionalPagesVmds.Base;
using ProjectMateTaskWpfTests.ServicesTests.NavigationServicesTests.Base;

namespace ProjectMateTaskWpfTests.ServicesTests.NavigationServicesTests.NavigationServicesTests;

[TestClass]
public class AdditionalPageStoreNavigationServiceTests : BaseStoreNavigationServicesAbstractTests<AdditionalPageStoreNavigationService,BaseAdditionalVmd>
{
    protected override AdditionalPageStoreNavigationService CreateSomeStore(
        IVmdNavigationStore<BaseAdditionalVmd> vmdNavigationStore, Func<BaseAdditionalVmd> createVmd) =>
        new(vmdNavigationStore, createVmd);

}