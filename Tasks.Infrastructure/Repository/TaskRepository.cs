using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using Tasks.Application.Interfaces.Repository;
using Tasks.Domain.Entities;

namespace Tasks.Infrastructure.Repository
{
    public class TaskRepository : Repository<Task>, ITaskRepository
    {
        public TaskRepository(DbSet<Task> entity) : base(entity)
        {

        }
        
        public System.Threading.Tasks.Task<Task> GetByIdWithMissionsAsync(Guid id, CancellationToken cancellationToken)
        {
            return _entity.Include(c => c.Missions).Where(c => c.Id == id).FirstOrDefaultAsync(cancellationToken);         
        }
    }
}
