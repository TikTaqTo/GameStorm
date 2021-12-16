using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using System.Threading;

namespace GameService.Shared.Testing.DbAsync {

  public class TestDbAsyncEnumerator<T> : IDbAsyncEnumerator<T> {
    private readonly IEnumerator<T> inner;

    public TestDbAsyncEnumerator(IEnumerator<T> inner) {
      this.inner = inner;
    }

    public void Dispose() {
      this.inner.Dispose();
    }

    public Task<bool> MoveNextAsync(CancellationToken cancellationToken) {
      return Task.FromResult(this.inner.MoveNext());
    }

    public T Current {
      get { return this.inner.Current; }
    }

    object IDbAsyncEnumerator.Current {
      get { return this.Current; }
    }
  }
}