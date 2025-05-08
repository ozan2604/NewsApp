using Application.Features.Mediatr.AppUserQueries;
using Application.Tools;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class LoginController : ControllerBase
    {
        public IMediator _mediator { get; set; }

        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Login(GetCheckAppUserQueryRequest query)
        {
            var values = await _mediator.Send(query);
            if (values.IsExist)
            {
                return Created("", jwtTokenGenerator.GenerateToken(values));
            }
            else
            {
                return BadRequest("Kullanıcı adı veya şifre hatalıdır");
            }
        }
    }
}
