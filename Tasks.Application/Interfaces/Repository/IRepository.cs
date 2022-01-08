using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Tasks.Application.Interfaces.Repository
{
    public interface IRepository<TEntity>
    {
        public Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        public Task<bool> ExistAsync(Guid id, CancellationToken cancellationToken = default);
        public ValueTask<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        public Task<List<TEntity>> GetAsync(CancellationToken cancellationToken = default);
        public void Remove(Guid id);
    }
}
