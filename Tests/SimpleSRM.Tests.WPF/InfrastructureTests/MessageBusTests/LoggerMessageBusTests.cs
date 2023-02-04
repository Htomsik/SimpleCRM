using SimpleSRM.Tests.WPF.InfrastructureTests.MessageBusTests.BaseMessageBusTests;
using SimpleSRM.WPF.Infrastructure.MessageBuses;

namespace SimpleSRM.Tests.WPF.InfrastructureTests.MessageBusTests;

[TestClass]
public class LoggerMessageBusTests : BaseMessageBusAbstractTests<LoggerMessageBus,string>
{
    protected override string GenerateSomeMessage() => "SomeMessage";

}