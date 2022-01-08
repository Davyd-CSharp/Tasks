using System.Threading;
using System.Threading.Tasks;
using Tasks.Application.Interfaces.Repository;

namespace Tasks.Application.Interfaces.DataAccess
{
    public interface IUnitOfWork 
    {
        public ITaskRepository Task { get; }
        public IMissionRepository Mission { get; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        public int SaveChanges();
    }
}
