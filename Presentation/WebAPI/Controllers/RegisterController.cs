using Application.Features.Mediatr.AppUserCommands.CreateAppUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class RegisterController : ControllerBase
    {
        public IMediator _mediator { get; set; }

        public RegisterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateAppUserCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok("Kullanıcı başarıyla oluşturuldu");
        }
    }
}
