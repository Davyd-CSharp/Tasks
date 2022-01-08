using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Tasks.Application.Interfaces.DataAccess;

namespace Tasks.Application.Features.TaskFeatures.Command
{
    public static class DeleteTask
    {
        public record Command(Guid taskId) : IRequest<Unit>;

        public class Handler : IRequestHandler<Command, Unit>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                if (!await _unitOfWork.Task.ExistAsync(request.taskId, cancellationToken)) 
                {
                    throw new Exception("Task not exist");
                }
                _unitOfWork.Task.Remove(request.taskId);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
