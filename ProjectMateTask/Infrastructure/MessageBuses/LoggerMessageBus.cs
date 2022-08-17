using System;

namespace ProjectMateTask.Infrastructure.MessageBuses;

public static class LoggerMessageBus
{
    public static event Action<string> Log;

    public static void Send(string logMessage)
        => Log?.Invoke(logMessage);
}