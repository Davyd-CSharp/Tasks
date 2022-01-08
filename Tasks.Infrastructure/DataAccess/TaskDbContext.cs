using Microsoft.EntityFrameworkCore;
using Tasks.Application.Interfaces.DataAccess;
using Tasks.Application.Interfaces.Repository;
using Tasks.Domain.Entities;
using Tasks.Infrastructure.Repository;

namespace Tasks.Infrastructure.DataAccess
{
    public class TaskDbContext : DbContext, IUnitOfWork
    {
        private DbSet<Task> _tasks { get; set; }
        private DbSet<Mission> _missions { get; set; }
    
        public ITaskRepository Task => new TaskRepository(_tasks);

        public IMissionRepository Mission => new MissionRepository(_missions);

        public TaskDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
