using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Tasks.Application.Interfaces.DataAccess;
using Tasks.Domain.Entities;

namespace Tasks.Application.Features.MissionFeatures.Command
{
    public static class CreateMission
    {
        public record Command(Guid TaskId,string Name, string Description) : IRequest<Mission>;

        public class Handler : IRequestHandler<Command, Mission>
        {
            private readonly IUnitOfWork _unitOfWork;

            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<Mission> Handle(Command request, CancellationToken cancellationToken)
            {
                if (!await _unitOfWork.Task.ExistAsync(request.TaskId, cancellationToken)) 
                {
                    throw new Exception("Task not exist");
                }
                var newMission = new Mission
                {
                    TaskId = request.TaskId,
                    Name = request.Name,
                    Description = request.Description,
                    IsDone = false
                };

                await _unitOfWork.Mission.AddAsync(newMission, cancellationToken);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return newMission;
            }
        }
    }
}
