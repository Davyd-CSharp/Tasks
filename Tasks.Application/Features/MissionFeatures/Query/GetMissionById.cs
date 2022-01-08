using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Tasks.Application.Interfaces.DataAccess;
using Tasks.Domain.Entities;

namespace Tasks.Application.Features.MissionFeatures.Query
{
    public static class GetMissionById
    {
        public record Query(Guid MissionId) : IRequest<Mission>;
        
        public class Handler : IRequestHandler<Query, Mission>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<Mission> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _unitOfWork.Mission.GetByIdAsync(request.MissionId, cancellationToken);
            }
        }
    }
}
