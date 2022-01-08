using MediatR;
using System;
using System.Threading;
using Tasks.Application.Interfaces.DataAccess;
using Tasks.Domain.Entities;

namespace Tasks.Application.Features.TaskFeatures.Query
{
    public static class GetTaskById
    {
        public record Query(Guid TaskId) : IRequest<Task>;

        public class Handler : IRequestHandler<Query, Task>
        {
            private readonly IUnitOfWork _unitOfWork;

            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async System.Threading.Tasks.Task<Task> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _unitOfWork.Task.GetByIdWithMissionsAsync(request.TaskId, cancellationToken);
            }
        }
    }
}
