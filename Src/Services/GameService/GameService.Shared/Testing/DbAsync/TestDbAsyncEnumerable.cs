﻿using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Infrastructure;
using System.Linq.Expressions;

namespace GameService.Shared.Testing.DbAsync {

  public class TestDbAsyncEnumerable<T> : EnumerableQuery<T>, IDbAsyncEnumerable<T>, IQueryable<T> {

    public TestDbAsyncEnumerable(IEnumerable<T> enumerable)
      : base(enumerable) { }

    public TestDbAsyncEnumerable(Expression expression)
      : base(expression) { }

    public IDbAsyncEnumerator<T> GetAsyncEnumerator() {
      return new TestDbAsyncEnumerator<T>(this.AsEnumerable().GetEnumerator());
    }

    IDbAsyncEnumerator IDbAsyncEnumerable.GetAsyncEnumerator() {
      return this.GetAsyncEnumerator();
    }

    IQueryProvider IQueryable.Provider {
      get { return new TestDbAsyncQueryProvider<T>(this); }
    }
  }
}