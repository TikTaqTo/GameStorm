using GameService.Shared.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameService.Application.Behaviors {

  public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> {
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

    public LoggingBehavior(IHttpContextAccessor httpContextAccessor,
            ILogger<LoggingBehavior<TRequest, TResponse>> logger) {
      _httpContextAccessor = httpContextAccessor;
      _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request,
            CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next) {
      _logger.LogInformation("----- Handling command {CommandName} ({@Command})", request.GetGenericTypeName(),
          request);

      var response = await next();

      _logger.LogInformation("----- Command {CommandName} handled - response: {@Response}",
          request.GetGenericTypeName(), response);

      return response;
    }
  }
}