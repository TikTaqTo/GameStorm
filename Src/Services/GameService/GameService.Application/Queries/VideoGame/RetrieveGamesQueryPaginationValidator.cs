using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Queries.VideoGame {
  public class RetrieveGamesQueryPaginationValidator : AbstractValidator<RetrieveGamesQueryPagination> {
    public RetrieveGamesQueryPaginationValidator() {
    }
  }
}
