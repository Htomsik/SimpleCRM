using System;
using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace ProjectMateTask.Services.AppInfrastructure;

/// <summary>
///         Глобальный обработчик исключений
/// </summary>
internal sealed class GlobalExceptionHandler : IObserver<Exception>
{
    private readonly ILogger _logger;

    public GlobalExceptionHandler(ILogger logger)
    {
        _logger = logger;
    }
    
    public void OnCompleted()
    {
        if (Debugger.IsAttached) Debugger.Break();
    }

    public void OnError(Exception error)
    {
        if (Debugger.IsAttached) Debugger.Break();
        _logger.LogError($"{error.Source}: {error.Message}", error);
    }

    public void OnNext(Exception value)
    {
        if (Debugger.IsAttached) Debugger.Break();

        _logger?.LogError($"{value.Source}: {value.Message}", value);
    }
}