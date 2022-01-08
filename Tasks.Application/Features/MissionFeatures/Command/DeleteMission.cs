using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Tasks.Application.Interfaces.DataAccess;

namespace Tasks.Application.Features.MissionFeatures.Command
{
    public static class DeleteMission
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
                if (!await _unitOfWork.Mission.ExistAsync(request.MissionId, cancellationToken)) 
                {
                    throw new Exception("Mission not exist");
                }

                _unitOfWork.Mission.Remove(request.MissionId);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
