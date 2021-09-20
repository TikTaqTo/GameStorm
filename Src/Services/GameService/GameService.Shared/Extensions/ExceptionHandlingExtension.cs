using System;
using System.Collections.Generic;

namespace GameService.Shared.Extensions {

  public static class ExceptionHandlingExtension {

    public static IEnumerable<string> GetInnerException(this Exception exception,
            ICollection<string> errors = null) {
      if (exception is not null) {
        errors ??= new List<string>();
        errors.Add(exception.Message);
        return exception.InnerException.GetInnerException(errors);
      }

      return errors;
    }
  }
}