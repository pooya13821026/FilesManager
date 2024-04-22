﻿using MediatR;
using Microsoft.Extensions.Logging;

namespace FilesManager.Application.Behaviors;
public class UnhandledExceptionBehavior<TRequest, TResponse>(ILogger<TRequest> logger) :
    IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (Exception e)
        {
            var requestName = typeof(TRequest).Name;
            logger.LogError(e, $"unhandled exception for request {requestName} : {request}");
            throw;
        }
    }
}
