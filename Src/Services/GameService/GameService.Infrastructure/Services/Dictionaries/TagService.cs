using GameService.Application.Abstractions.Dictionaries;
using GameService.Domain.EntityModels.Dictionaries;
using GameService.Domain.Replies;
using GameService.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameService.Infrastructure.Services.Dictionaries {

  public class TagService : ITagService {
    private readonly GameServiceContext _context;

    public TagService(GameServiceContext context) {
        _context = context;
          
        List<Tag> tags = new List<Tag>() 
        {
            new Tag()
            {
                Id = 1,
                Name = "Action",
                NormalizedName = "action",
            },
            new Tag()
            {
                Id = 2,
                Name = "Indie",
                NormalizedName = "indie",
            },
            new Tag()
            {
                Id = 3,
                Name = "Adventure",
                NormalizedName = "adventure",
            },
            new Tag()
            {
                Id = 4,
                Name = "Strategy",
                NormalizedName = "strategy",
            },
        };

        _context.Tags.AddRange(tags);
        _context.SaveChanges();
    }

    public async Task<TagReply> CreateTag(Tag tag) {
      await _context.Tags.AddAsync(tag);
      await _context.SaveChangesAsync();
      return new TagReply() {
        Tag = tag
      };
    }

    public async Task<TagReply> DeleteTagById(int id) {
      var tag = _context.Tags.Find(id);
      tag.DeletedAt = DateTimeOffset.Now;
      tag.DeletedBy = "admin";
      tag.DeletedReason = "delete info";
      await _context.SaveChangesAsync();
      return new TagReply {
        Tag = tag
      };
    }

    public async Task<TagsReply> RetrieveTags() {
      var allTags = _context.Tags;
      var tagsReply = new TagsReply() {
        Tags = allTags
      };
      return await Task.FromResult(tagsReply);
    }

    public async Task<TagReply> UpdateTag(Tag tag) {
      _context.Tags.Update(tag);
      await _context.SaveChangesAsync();
      return new TagReply() {
        Tag = tag
      };
    }
  }
}