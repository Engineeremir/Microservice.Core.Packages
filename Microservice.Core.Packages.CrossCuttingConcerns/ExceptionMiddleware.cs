﻿using Microservice.Core.Packages.CrossCuttingConcerns.Exceptions.Handlers;
using Microservice.Core.Packages.CrossCuttingConcerns.Logging;
using Microservice.Core.Packages.CrossCuttingConcerns.Logging.Serilog;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Microservice.Core.Packages.CrossCuttingConcerns;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly HttpExceptionHandler _httpExceptionHandler;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly LoggerServiceBase _loggerService;

    public ExceptionMiddleware(RequestDelegate next,
        IHttpContextAccessor contextAccessor, LoggerServiceBase loggerService)
    {
        _next = next;
        _httpExceptionHandler = new HttpExceptionHandler();
        _contextAccessor = contextAccessor;
        _loggerService = loggerService;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            await LogException(context, exception);
            await HandleExceptionAsync(context.Response, exception);
        }

    }

    private Task LogException(HttpContext context, Exception exception)
    {
        List<LogParameter> logParameters = new()
        {
            new LogParameter{Type=context.GetType().Name, Value=exception.ToString()}
        };

        LogDetailWithException logDetail = new()
        {
            ExceptionMessage = exception.Message,
            MethodName = _next.Method.Name,
            Parameters = logParameters,
            User = _contextAccessor.HttpContext?.User.Identity?.Name ?? "?"
        };

        _loggerService.Error(JsonSerializer.Serialize(logDetail));

        return Task.CompletedTask;
    }

    private Task HandleExceptionAsync(HttpResponse response, Exception exception)
    {
        response.ContentType = "application/json";
        _httpExceptionHandler.Response = response;
        return _httpExceptionHandler.HandleExceptionAsync(exception);
    }
}
