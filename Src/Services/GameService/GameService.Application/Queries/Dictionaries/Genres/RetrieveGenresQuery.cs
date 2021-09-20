using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Queries.Dictionaries.Genres {

  public class RetrieveGenresQuery : IRequest<GenresReply> {
  }
}