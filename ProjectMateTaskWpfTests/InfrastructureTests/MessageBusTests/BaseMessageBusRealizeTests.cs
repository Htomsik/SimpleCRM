using ProjectMateTask.Infrastructure.MessageBuses.Base;
using ProjectMateTaskWpfTests.InfrastructureTests.MessageBusTests.BaseMessageBusTests;

namespace ProjectMateTaskWpfTests.InfrastructureTests.MessageBusTests;

[TestClass]
public class BaseMessageBusRealizeTests : BaseMessageBusAbstractTests<BaseMessageBus<string>,string>
{
    protected override string GenerateSomeMessage() => "SomeMessage";

}