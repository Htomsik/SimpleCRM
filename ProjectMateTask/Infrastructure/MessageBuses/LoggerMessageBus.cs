using ProjectMateTask.Infrastructure.MessageBuses.Base;

namespace ProjectMateTask.Infrastructure.MessageBuses;

/// <summary>
///     Шина сообщений для логгера
/// </summary>
public sealed class LoggerMessageBus : BaseMessageBus<string>
{
}