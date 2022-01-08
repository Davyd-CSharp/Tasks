using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;
using Tasks.Application.Features.MissionFeatures.Command;
using Tasks.Application.Features.MissionFeatures.Query;

namespace Tasks.RestApi.Controllers
{
    public class MissionController : Controller
    {
        private readonly IMediator _mediator;

        public MissionController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Create() 
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetMission(Guid id , CancellationToken cancellation = default) 
        {
            var mission = await _mediator.Send(new GetMissionById.Query(id), cancellation);

            return View(mission);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateMission.Command command, CancellationToken cancellationToken = default) 
        {
            await _mediator.Send(command, cancellationToken);
            return StatusCode(200);
        }
        [HttpPost]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken = default)
        {
            await _mediator.Send(new DeleteMission.Command(id), cancellationToken);

            return StatusCode(200);
        }
        [HttpGet]
        public async Task<IActionResult> ChangeStatus(Guid id, CancellationToken cancellationToken = default) 
        {
            await _mediator.Send(new ChangeStatusMission.Command(id), cancellationToken);

            return StatusCode(200);
        }
    }
}
