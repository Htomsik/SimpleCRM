using System;
using ProjectMateTask.DAL.Entities.Base;


namespace ProjectMateTask.Infrastructure.MessageBuses;

internal static  class SelectedSubEntityMessageBus 
{
    public static event Action<IEntity>? Bus;

    public static void Send(IEntity data) => Bus?.Invoke(data);

}