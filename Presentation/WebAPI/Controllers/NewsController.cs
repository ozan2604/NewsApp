using Application.Features.Mediatr.NewsCommands.CreateNews;
using Application.Features.Mediatr.NewsCommands.RemoveNews;
using Application.Features.Mediatr.NewsCommands.UpdateNews;
using Application.Features.Mediatr.NewsQueries.GetAllNews;
using Application.Features.Mediatr.NewsQueries.GetByIdNews;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NewsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNews([FromQuery] bool onlyAI)
        {
            var request = new GetAllNewsQueryRequest { OnlyAIGenerated = onlyAI };
            var response = await _mediator.Send(request);
            return Ok(response.NewsList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdNews(Guid id)
        {
            var request = new GetByIdNewsQueryRequest { Id = id };
            var response = await _mediator.Send(request);
            return Ok(response.News);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNews([FromBody] CreateNewsCommandRequest request)
        {
            CreateNewsCommandResponse response = await _mediator.Send(request);
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateNews([FromBody] UpdateNewsCommandRequest request)
        {
            UpdateNewsCommandResponse response = await _mediator.Send(request);
            return Ok(response.Message);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteBlog([FromRoute] RemoveNewsCommandRequest request)
        {
            RemoveNewsCommandResponse response = await _mediator.Send(request);
            return Ok(response.Message);
        }
    }
}