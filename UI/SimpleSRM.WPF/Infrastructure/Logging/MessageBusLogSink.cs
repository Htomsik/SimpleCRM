using System;
using Microsoft.Extensions.DependencyInjection;
using Serilog.Core;
using Serilog.Events;
using SimpleSRM.WPF.Infrastructure.MessageBuses;

namespace SimpleSRM.WPF.Infrastructure.Logging;

/// <summary>
///     Раковина для логгера отправляющая информаицю в шину сообщений
/// </summary>
internal sealed class MessageBusLogSink: ILogEventSink
{
    private readonly Lazy<LoggerMessageBus> _loggerMessageBus;
    public MessageBusLogSink() => _loggerMessageBus = new Lazy<LoggerMessageBus>(()=> App.Services.GetRequiredService<LoggerMessageBus>());
   
    public void Emit(LogEvent logEvent) =>_loggerMessageBus.Value.Send(logEvent.RenderMessage());
   
}