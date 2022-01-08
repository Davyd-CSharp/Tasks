using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Tasks.Application.Interfaces.DataAccess;
using Tasks.Domain.Entities;

namespace Tasks.Application.Features.TaskFeatures.Command
{
    public static class UpdateTask
    {
        public record Command(Guid TaskId, string Name, List<Mission> Missions) : IRequest<Unit>;

        public class Handler : IRequestHandler<Command, Unit>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var task = await _unitOfWork.Task.GetByIdAsync(request.TaskId);
                if(task == null) 
                {
                    throw new Exception("task not exist");
                }

                task.Name = request.Name;
                task.Missions = request.Missions;

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
