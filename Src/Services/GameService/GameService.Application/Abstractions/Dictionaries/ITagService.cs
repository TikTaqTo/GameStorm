using GameService.Domain.EntityModels.Dictionaries;
using GameService.Domain.Replies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Abstractions.Dictionaries {

  public interface ITagService {

    Task<TagReply> CreateTag(Tag tag);

    Task<TagReply> UpdateTag(Tag tag);

    Task<TagsReply> RetrieveTags();

    Task<TagReply> DeleteTagById(int id);
  }
}