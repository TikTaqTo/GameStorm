using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserIdentityService.Shared.Extensions {
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
