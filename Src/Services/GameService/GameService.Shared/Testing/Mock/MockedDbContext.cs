using System;
using System.Collections.Generic;
using System.Data.Entity;
using Moq;

namespace GameService.Shared.Testing.Mock {

  public class MockedDbContext<TDbContext>
    where TDbContext : DbContext {
    private readonly Dictionary<Type, object> dbSets = new Dictionary<Type, object>();

    public MockedDbContext(Mock<TDbContext> dbContextMock, params object[] dbSetMocks) {
      this.DbContext = dbContextMock;

      foreach (var dbSetMock in dbSetMocks) {
        this.dbSets.Add(dbSetMock.GetType(), dbSetMock);
      }
    }

    public Mock<TDbContext> DbContext { get; set; }

    public Mock<DbSet<TEntity>> GetDbSet<TEntity>() where TEntity : class {
      return this.dbSets[typeof(Mock<DbSet<TEntity>>)] as Mock<DbSet<TEntity>>;
    }
  }
}