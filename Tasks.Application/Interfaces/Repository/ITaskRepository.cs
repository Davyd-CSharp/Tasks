using System;
using System.Threading;
using Tasks.Domain.Entities;

namespace Tasks.Application.Interfaces.Repository
{
    public interface ITaskRepository : IRepository<Task>
    {
        public System.Threading.Tasks.Task<Task> GetByIdWithMissionsAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
