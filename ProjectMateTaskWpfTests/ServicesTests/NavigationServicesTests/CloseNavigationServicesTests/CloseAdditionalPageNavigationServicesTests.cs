using ProjectMateTask.Services.AppInfrastructure.NavigationServices.CloseNavigationServcies;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores.Base;
using ProjectMateTask.VMD.Pages.AdditionalPagesVmds.Base;
using ProjectMateTaskWpfTests.ServicesTests.NavigationServicesTests.Base;

namespace ProjectMateTaskWpfTests.ServicesTests.NavigationServicesTests.CloseNavigationServicesTests;

[TestClass]
public class CloseAdditionalPageNavigationServicesTests : BaseCloseNavigationServicesAbstractTest<CloseAdditionalPageNavigationServices,BaseAdditionalVmd>
{
    protected override CloseAdditionalPageNavigationServices CreateSomeStore(
        IVmdNavigationStore<BaseAdditionalVmd> vmdNavigationStore) => new(vmdNavigationStore);

}