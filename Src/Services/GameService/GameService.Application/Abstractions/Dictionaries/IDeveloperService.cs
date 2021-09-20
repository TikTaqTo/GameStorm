using GameService.Domain.EntityModels.Dictionaries;
using GameService.Domain.Replies;
using System;
using System.Threading.Tasks;

namespace GameService.Application.Abstractions.Dictionaries {

  public interface IDeveloperService {

    Task<DeveloperReply> CreateDeveloper(Developer developer);

    Task<DeveloperReply> UpdateDeveloper(Developer developer);

    Task<DevelopersReply> RetrieveDevelopers();

    Task<DeveloperReply> DeleteDeveloperById(int id);
  }
}