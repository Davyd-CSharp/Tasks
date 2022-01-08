using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;
using Tasks.Application.Features.TaskFeatures.Command;
using Tasks.Application.Features.TaskFeatures.Query;

namespace Tasks.RestApi.Controllers
{
    public class TaskController : Controller
    {
        private readonly IMediator _mediator;
        public TaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken = default) 
        {
            var tasks = await _mediator.Send(new GetTask.Query(), cancellationToken);

            return View(tasks);
        }
        [HttpGet]
        public async Task<IActionResult> GetTask(Guid id, CancellationToken cancellationToken = default) 
        {
            var task = await _mediator.Send(new GetTaskById.Query(id), cancellationToken);

            return View(task);
        }
        [HttpGet]
        public async Task<IActionResult> Create() 
        {
            return View();
        } 
        [HttpPost]
        public async Task<IActionResult> Create(CreateTask.Command command, CancellationToken cancellationToken = default) 
        {
            var newTask = await _mediator.Send(command, cancellationToken);

            return View();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken = default) 
        {
            await _mediator.Send(new DeleteTask.Command(id), cancellationToken);

            return StatusCode(200);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateTask.Command command, CancellationToken cancellationToken  = default) 
        {
            await _mediator.Send(command, cancellationToken);

            return StatusCode(200);
        }
    }
}
