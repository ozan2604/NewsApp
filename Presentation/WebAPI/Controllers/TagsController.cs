using Application.Features.Mediatr.TagCommands.CreateTag;
using Application.Features.Mediatr.TagCommands.RemoveTag;
using Application.Features.Mediatr.TagCommands.UpdateTag;
using Application.Features.Mediatr.TagQueries.GetAllTag;
using Application.Features.Mediatr.TagQueries.GetByIdTag;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TagsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllTagQueryRequest());
            return Ok(result.Tags);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetTagByIdQueryRequest { Id = id });
            return Ok(result.Tag);
        }

        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTagCommandRequest request)
        {
            CreateTagCommandResponse response = await _mediator.Send(request);
            return StatusCode((int)HttpStatusCode.Created);
        }

        
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTagCommandRequest request)
        {
            UpdateTagCommandResponse response = await _mediator.Send(request);
            return Ok(response.Message);

            
        }

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new RemoveTagCommandRequest { Id = id });
            return Ok(result.Message);
        }
    }
}
