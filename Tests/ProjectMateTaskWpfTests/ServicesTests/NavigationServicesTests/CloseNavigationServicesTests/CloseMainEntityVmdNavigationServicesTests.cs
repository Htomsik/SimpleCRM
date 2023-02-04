using ProjectMateTask.Services.AppInfrastructure.NavigationServices.CloseNavigationServcies;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores.Base;
using ProjectMateTask.VMD.Pages.Entities.Base;
using ProjectMateTaskWpfTests.ServicesTests.NavigationServicesTests.Base;

namespace ProjectMateTaskWpfTests.ServicesTests.NavigationServicesTests.CloseNavigationServicesTests;

[TestClass]
public class CloseMainEntityVmdNavigationServicesTests : BaseCloseNavigationServicesAbstractTest<CloseMainEntityVmdNavigationServices,BaseEntityVmd>
{
    protected override CloseMainEntityVmdNavigationServices CreateSomeStore(
        IVmdNavigationStore<BaseEntityVmd> vmdNavigationStore) => new(vmdNavigationStore);

}