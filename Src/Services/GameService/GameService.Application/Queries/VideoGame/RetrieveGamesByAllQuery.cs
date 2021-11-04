using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Queries.VideoGame {

  public class RetrieveGamesByAllQuery : IRequest<GamesReply> {

    public RetrieveGamesByAllQuery(string genre, string gameSortOrder, string platform, DateTimeOffset? dateReleaseStart, DateTimeOffset? dateReleaseEnd, int page, int pageSize) {
      Genre = genre;
      GameSortOrder = gameSortOrder;
      Platform = platform;
      DateReleaseStart = dateReleaseStart;
      DateReleaseEnd = dateReleaseEnd;
      Page = page;
      PageSize = pageSize;
    }

    public string Genre { get; }

    public string GameSortOrder { get; set; }

    public string Platform { get; }

    public DateTimeOffset? DateReleaseStart { get; }

    public DateTimeOffset? DateReleaseEnd { get; }

    public int Page { get; }

    public int PageSize { get; }
  }
}