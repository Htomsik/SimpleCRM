using ProjectMateTask.Infrastructure.MessageBuses;
using Serilog.Core;
using Serilog.Events;

namespace ProjectMateTask.Infrastructure.Logging;

public class MessageBusLogSink: ILogEventSink
{
    public void Emit(LogEvent logEvent)
    {
        LoggerMessageBus.Send(logEvent.RenderMessage());
        
    }
}