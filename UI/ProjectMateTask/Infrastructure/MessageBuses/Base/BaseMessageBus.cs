using System;

namespace ProjectMateTask.Infrastructure.MessageBuses.Base;

/// <summary>
///     Базовый тип для шин сообщений
/// </summary>
/// <typeparam name="T">Любой тип</typeparam>
public class BaseMessageBus<T> : IMessageBus<T>
{
    public event Action<T>? Bus;

    public void Send(T message) =>  Bus?.Invoke(message);
   
}