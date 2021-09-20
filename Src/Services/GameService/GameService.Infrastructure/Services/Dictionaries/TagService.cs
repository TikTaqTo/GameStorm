using GameService.Application.Abstractions.Dictionaries;
using GameService.Domain.EntityModels.Dictionaries;
using GameService.Domain.Replies;
using GameService.Infrastructure.Persistence;
using System;
using System.Threading.Tasks;

namespace GameService.Infrastructure.Services.Dictionaries {

  public class TagService : ITagService {
    private readonly GameServiceContext _context;

    public TagService(GameServiceContext context) {
      _context = context;
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