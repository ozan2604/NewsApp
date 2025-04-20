using Application.Features.Mediatr.AiLogCommands.CreateAiLogCommands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AiLogsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AiLogsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAilogCommandRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Prompt))
                return BadRequest("Prompt boş olamaz");

            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
