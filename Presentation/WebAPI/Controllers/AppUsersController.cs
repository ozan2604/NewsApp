using Application.Features.Mediatr.AiLogsQueries.GetByIDAiLogs;
using Application.Features.Mediatr.AppUserCommands.RemoveAppUser;
using Application.Features.Mediatr.AppUserCommands.UpdateAppUser;
using Application.Features.Mediatr.AppUserQueries.GetByIdAppUser;
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
    public class AppUsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AppUsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetByIdAppUserQueryRequest { Id = id });

            if (result == null)
                return NotFound();

            return Ok(result);
        }


        [HttpPut]
        [AllowAnonymous]
        public async Task<IActionResult> Update([FromBody] UpdateAppUserCommandRequest request)
        {
            UpdateAppUserCommandResponse response = await _mediator.Send(request);
            return Ok(response.Message);


        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new RemoveAppUserCommandRequest { Id = id });
            return Ok(result.Message);
        }
    }
}
