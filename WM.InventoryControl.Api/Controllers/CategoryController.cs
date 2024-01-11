using MediatR;
using Microsoft.AspNetCore.Mvc;
using WM.InventoryControl.Application.Commands.CategoryCommands;
using WM.InventoryControl.Application.Queries.CategoryQueries;

namespace WM.InventoryControl.Api.Controllers
{
    [ApiController]
    [Route("v1/category")]
    public class CategoryController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddCategoryCommand command)
        {
            try
            {
                var categoryId = await _mediator.Send(command);

                return Created(nameof(Get), new { categoryId });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _mediator.Send(new GetAllCategoryQuery()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            try
            {
                var category = await _mediator.Send(new GetCategoryQuery(id));

                if (category is null) return NotFound();

                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
