using System;

namespace ProjectMateTask.Infrastructure.MessageBuses.Base;

/// <summary>
///     Интерфейс шины сообщений
/// </summary>
/// <typeparam name="T">Любой тип</typeparam>
public interface IMessageBus<T>
{
    /// <summary>
    ///     Уведомитель о получении сообщения
    /// </summary>
    event Action<T> Bus;

    /// <summary>
    ///     Отправка сообщений всем подписанным на уведомитель
    /// </summary>
    /// <param name="message">Сообщение для подписчеков</param>
    public void Send(T Message);
}