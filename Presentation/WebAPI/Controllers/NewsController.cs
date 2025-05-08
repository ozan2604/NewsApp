using Application.Features.Mediatr.NewsCommands.AddTagToNews;
using Application.Features.Mediatr.NewsCommands.CreateNews;
using Application.Features.Mediatr.NewsCommands.RemoveNews;
using Application.Features.Mediatr.NewsCommands.RemoveTagFromNews;
using Application.Features.Mediatr.NewsCommands.UpdateNews;
using Application.Features.Mediatr.NewsQueries.GetAllNews;
using Application.Features.Mediatr.NewsQueries.GetByIdNews;
using Application.Features.Mediatr.NewsQueries.GetNewsByTag;
using Application.Features.Mediatr.TagQueries.GetAllTag;
using Application.Features.Mediatr.TagQueries.GetByIdTag;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class NewsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NewsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllNewsQueryRequest());
            return Ok(result);
        }

        [HttpGet("ByTag")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByTag([FromQuery] string tag)
        {
            var response = await _mediator.Send(new GetNewsByTagQueryRequest { TagName = tag });
            return Ok(response);
        }

        [HttpPost("AddTagToNews")]
        [AllowAnonymous]
        public async Task<IActionResult> AddTagToNews([FromForm] Guid newsId, [FromForm] Guid tagId)
        {
            var command = new AddTagToNewsCommandRequest
            {
                NewsId = newsId,
                TagId = tagId
            };

            var result = await _mediator.Send(command);
            return Ok(result.Message);
        }

        [HttpPost("RemoveTagFromNews")]
        [AllowAnonymous]
        public async Task<IActionResult> RemoveTagFromNews([FromForm] Guid newsId, [FromForm] Guid tagId)
        {
            var command = new RemoveTagFromNewsCommandRequest
            {
                NewsId = newsId,
                TagId = tagId
            };

            var response = await _mediator.Send(command);
            return Ok(response.Message);
        }


        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByIdNews(Guid id)
        {
            try
            {
                var request = new GetByIdNewsQueryRequest { Id = id };
                var response = await _mediator.Send(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateNews([FromBody] CreateNewsCommandRequest request)
        {
            CreateNewsCommandResponse response = await _mediator.Send(request);
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateNews([FromBody] UpdateNewsCommandRequest request)
        {
            UpdateNewsCommandResponse response = await _mediator.Send(request);
            return Ok(response.Message);
        }

        [HttpDelete("{Id}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteBlog([FromRoute] RemoveNewsCommandRequest request)
        {
            RemoveNewsCommandResponse response = await _mediator.Send(request);
            return Ok(response.Message);
        }
    }
}