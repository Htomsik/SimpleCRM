using SimpleSRM.WPF.Infrastructure.MessageBuses.Base;

namespace SimpleSRM.WPF.Infrastructure.MessageBuses;

/// <summary>
///     Шина сообщений для логгера
/// </summary>
public sealed class LoggerMessageBus : BaseMessageBus<string>
{
}