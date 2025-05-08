using Application.Features.Mediatr.AiLogsCommands.CreateAiLogsCommand;
using Application.Features.Mediatr.AiLogsCommands.RemoveAiLogsCommand;
using Application.Features.Mediatr.AiLogsCommands.UpdateAiLogsCommand;
using Application.Features.Mediatr.AiLogsQueries.GetAllAiLogs;
using Application.Features.Mediatr.AiLogsQueries.GetByIDAiLogs;
using Application.Features.Mediatr.TagCommands.RemoveTag;
using Application.Features.Mediatr.TagCommands.UpdateTag;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AiLogsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AiLogsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAiLogsQueryRequest());
            return Ok(result);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetByIDAiLogsQueryRequest { Id = id });

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAilogsCommandRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Prompt))
                return BadRequest("Prompt boş olamaz");

            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPut]
        [AllowAnonymous]
        public async Task<IActionResult> Update([FromBody] UpdateAiLogsCommandRequest request)
        {
            UpdateAiLogsCommandResponse response = await _mediator.Send(request);
            return Ok(response.Message);


        }

        [HttpDelete("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new RemoveAiLogsCommandRequest { Id = id });
            return Ok(result.Message);
        }
    }
}
