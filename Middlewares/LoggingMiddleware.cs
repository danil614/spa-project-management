using System.Diagnostics;

namespace SpaProjectManagement.Middlewares;

public class LoggingMiddleware(RequestDelegate next, ILoggerFactory? loggerFactory)
{
    private readonly ILogger<LoggingMiddleware> _logger = loggerFactory?.CreateLogger<LoggingMiddleware>() ??
                                                          throw new ArgumentNullException(nameof(loggerFactory));

    public async Task InvokeAsync(HttpContext context)
    {
        // Логирование начала обработки запроса
        var stopwatch = Stopwatch.StartNew();
        var request = context.Request;
        _logger.LogInformation(
            "[{Now}] Start Request: {Method} {Path}", DateTime.Now, request.Method, request.Path);

        // Передача управления следующему middleware в конвейере
        await next(context);

        // Логирование окончания обработки запроса
        stopwatch.Stop();
        var response = context.Response;
        _logger.LogInformation(
            "[{Now}] End Request: {StatusCode}. Duration: {Duration} ms",
            DateTime.Now, response.StatusCode, stopwatch.ElapsedMilliseconds);
    }
}