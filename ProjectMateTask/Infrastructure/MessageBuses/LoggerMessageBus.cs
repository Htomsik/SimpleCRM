using ProjectMateTask.Infrastructure.MessageBuses.Base;

namespace ProjectMateTask.Infrastructure.MessageBuses;

/// <summary>
///     Шина сообщений для логгера
/// </summary>
internal sealed class LoggerMessageBus : BaseMessageBus<string>
{
}