using ProjectMateTask.Infrastructure.MessageBuses;
using ProjectMateTaskWpfTests.InfrastructureTests.MessageBusTests.BaseMessageBusTests;

namespace ProjectMateTaskWpfTests.InfrastructureTests.MessageBusTests;

[TestClass]
public class LoggerMessageBusTests : BaseMessageBusAbstractTests<LoggerMessageBus,string>
{
    protected override string GenerateSomeMessage() => "SomeMessage";

}