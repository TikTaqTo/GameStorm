using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UserIdentityService.Shared;

namespace UserIdentityService.Application.Behaviors {
  public class ValidatorBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse> {
    private readonly ILogger<ValidatorBehavior<TRequest, TResponse>> _logger;
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidatorBehavior(ILogger<ValidatorBehavior<TRequest, TResponse>> logger,
        IEnumerable<IValidator<TRequest>> validators) {
      _logger = logger;
      _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request,
            CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next) {
      if (_validators.Any()) {
        var typeName = request.GetGenericTypeName();
        _logger.LogInformation("----- Validating command {CommandType}", typeName);
        var context = new ValidationContext<TRequest>(request);
        var validationResults =
            await Task.WhenAll(_validators.Select(s =>
                s.ValidateAsync(context, cancellationToken)));
        var failures = validationResults
            .SelectMany(s => s.Errors)
            .Where(w => w is not null).ToList();

        if (failures.Any()) {
          _logger.LogWarning(
              "Validation errors - {CommandType} - Command: {@Command} - Errors: {@ValidationErrors}",
              typeName, request, failures);

          throw new ValidationException("Validation exception", failures);
        }
      }

      return await next();
    }
  }
}
