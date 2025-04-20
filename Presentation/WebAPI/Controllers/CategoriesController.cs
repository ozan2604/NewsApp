using Application.Features.Mediatr.CategoryCommands.CreateCategory;
using Application.Features.Mediatr.CategoryCommands.RemoveCategory;
using Application.Features.Mediatr.CategoryCommands.UpdateCategory;
using Application.Features.Mediatr.CategoryQueries.GetAllCategory;
using Application.Features.Mediatr.CategoryQueries.GetByIdCategory;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var result = await _mediator.Send(new GetAllCategoryQueryRequest());
            return Ok(result.Categories);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdCategories(Guid id)
        {
            var result = await _mediator.Send(new GetCategoryByIdQueryRequest { Id = id });

            return Ok(result.Category);
        }

        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return CreatedAtAction(nameof(GetByIdCategories), new { id = result.Category!.Id }, result.Category);
        }

        
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryCommandRequest request)
        {

            var result = await _mediator.Send(request);
            return Ok(result.Message);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new RemoveCategoryCommandRequest { Id = id });
            return Ok(result.Message);
        }
    }
}
