using System;
using ProjectMateTask.Infrastructure.MessageBuses;
using Serilog.Core;
using Serilog.Events;

namespace ProjectMateTask.Infrastructure.Logging;

public class MessageBusLogSink: ILogEventSink
{
    private readonly Lazy<LoggerMessageBus> _loggerMessageBus;
    public MessageBusLogSink() => _loggerMessageBus = new Lazy<LoggerMessageBus?>(()=> (LoggerMessageBus)App.Services.GetService(typeof(LoggerMessageBus)));
   
    public void Emit(LogEvent logEvent) =>_loggerMessageBus.Value.Send(logEvent.RenderMessage());
   
}