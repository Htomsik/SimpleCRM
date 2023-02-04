using SimpleSRM.Tests.WPF.InfrastructureTests.MessageBusTests.BaseMessageBusTests;
using SimpleSRM.WPF.Infrastructure.MessageBuses.Base;

namespace SimpleSRM.Tests.WPF.InfrastructureTests.MessageBusTests;

[TestClass]
public class BaseMessageBusRealizeTests : BaseMessageBusAbstractTests<BaseMessageBus<string>,string>
{
    protected override string GenerateSomeMessage() => "SomeMessage";

}