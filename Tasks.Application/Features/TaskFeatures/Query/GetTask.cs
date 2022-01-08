using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Tasks.Application.Interfaces.DataAccess;
using Tasks.Domain.Entities;

namespace Tasks.Application.Features.TaskFeatures.Query
{
    public static class GetTask
    {
        public record Query() : IRequest<List<Task>>;

        public class Handler : IRequestHandler<Query, List<Task>>
        {
            private readonly IUnitOfWork _unitOfWork;

            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async System.Threading.Tasks.Task<List<Task>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _unitOfWork.Task.GetAsync(cancellationToken);
            }
        }
    }
}
