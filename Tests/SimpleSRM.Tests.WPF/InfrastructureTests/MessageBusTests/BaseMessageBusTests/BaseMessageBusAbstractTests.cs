using SimpleSRM.WPF.Infrastructure.MessageBuses.Base;

namespace SimpleSRM.Tests.WPF.InfrastructureTests.MessageBusTests.BaseMessageBusTests;


public abstract class BaseMessageBusAbstractTests<TMessageBus,TValue> where TMessageBus : BaseMessageBus<TValue>, new()
{
    /// <summary>
    ///     Уведомляет ли шина о пришедшем сообщении
    /// </summary>
    [TestMethod]
    public void IsBusInvoke()
    {
        //Arrange
        TValue someMessage = GenerateSomeMessage(); 
            
        var someBus = new TMessageBus();

        //Act + Assert
        someBus.Bus += getMessage;
        
        someBus.Send(someMessage);
        
        void getMessage(TValue message)
        {
            Assert.AreEqual(someMessage,message);
        }
        
    }

    protected abstract TValue GenerateSomeMessage();
}