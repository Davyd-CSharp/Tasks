using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Tasks.Application.Interfaces.Repository;
using Tasks.Domain.Abstarct;

namespace Tasks.Infrastructure.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected DbSet<TEntity> _entity;
        public Repository(DbSet<TEntity> entity)
        {
            _entity = entity;
        }
        public virtual async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
             await _entity.AddAsync(entity, cancellationToken);
        }

        public Task<bool> ExistAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return _entity.AnyAsync(c => c.Id == id, cancellationToken);
        }

        public virtual Task<List<TEntity>> GetAsync(CancellationToken cancellationToken = default)
        {
            return _entity.ToListAsync(cancellationToken);
        }

        public virtual ValueTask<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return _entity.FindAsync(new object[] { id }, cancellationToken);
        }

        public virtual void Remove(Guid id)
        {
            var attachedEntity = _entity.Attach(new TEntity { Id = id });
            attachedEntity.State = EntityState.Deleted;
        }
    }
}
