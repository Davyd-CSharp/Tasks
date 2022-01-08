using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using Tasks.Application.Interfaces.DataAccess;
using Tasks.Domain.Entities;

namespace Tasks.Application.Features.TaskFeatures.Command
{
    public static class CreateTask
    {
        public record Command(string Name, List<Mission> Missions) : IRequest<Task>;

        public class Handler : IRequestHandler<Command, Task>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async System.Threading.Tasks.Task<Task> Handle(Command request, CancellationToken cancellationToken)
            {
                var newTask = new Task
                {
                    Name = request.Name,
                    Missions = request.Missions,
                    Created = DateTime.Now
                };

                await _unitOfWork.Task.AddAsync(newTask, cancellationToken);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return newTask;
            }
        }
    }
}
