using System.Data.Common;
using System.Linq;
using System.Runtime.Serialization;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using GameService.Api.Model.Replies;
using GameService.Shared.Extensions;

namespace GameService.Api.Filters {
  public class HttpGlobalExceptionFilter : IExceptionFilter {
    private readonly ILogger<HttpGlobalExceptionFilter> _logger;

    /// <summary>
    ///
    /// </summary>
    /// <param name="logger"></param>
    public HttpGlobalExceptionFilter(ILogger<HttpGlobalExceptionFilter> logger) {
      _logger = logger;
    }

    /// <summary>
    ///     Catching exceptions
    /// </summary>
    /// <param name="context">Exception context</param>
    public void OnException(ExceptionContext context) {
      _logger.LogCritical("LogCritical {0}", context.Exception);

      switch (context.Exception) {
        case ValidationException validationException: {
            if (validationException.Errors is not null && validationException.Errors.Any()) {
              var errorsMessages = validationException.Errors
                  .Select(s => s.ErrorMessage)
                  .ToList();
              errorsMessages.AddRange(validationException.GetInnerException());
              context.Result = new BadRequestObjectResult(new CommonReply {
                Errors = errorsMessages
              });
            }

            break;
          }
        case DbException dbException: {
            context.Result = new BadRequestObjectResult(new CommonReply {
              Errors = dbException.GetInnerException()
            });
            break;
          }
        case SerializationException badRequestException: {
            context.Result = new BadRequestObjectResult(new CommonReply {
              Errors = badRequestException.GetInnerException()
            });

            break;
          }
        default:
          context.Result = new BadRequestObjectResult(new CommonReply {
            Errors = context.Exception.GetInnerException()
          });
          break;
      }

      context.ExceptionHandled = true;
    }
  }
  }

