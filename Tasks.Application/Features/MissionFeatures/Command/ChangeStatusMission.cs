using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Tasks.Application.Interfaces.DataAccess;

namespace Tasks.Application.Features.MissionFeatures.Command
{
    public static class ChangeStatusMission
    {
        public record Command(Guid MissionId) : IRequest<Unit>;

        public class Handler : IRequestHandler<Command, Unit>
        {
            private readonly IUnitOfWork _unitOfWork;

            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var mission = await _unitOfWork.Mission.GetByIdAsync(request.MissionId, cancellationToken);
                if (mission == null) 
                {
                    throw new Exception("Mission not exist");
                }
                mission.IsDone = !mission.IsDone;

                await _unitOfWork.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
