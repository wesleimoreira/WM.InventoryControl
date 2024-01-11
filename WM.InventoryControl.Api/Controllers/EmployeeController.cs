using MediatR;
using Microsoft.AspNetCore.Mvc;
using WM.InventoryControl.Application.Commands.EmployeeCommands;
using WM.InventoryControl.Application.Queries.EmployeeQueries;

namespace WM.InventoryControl.Api.Controllers
{
    [ApiController]
    [Route("v1/employee")]
    public class EmployeeController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddEmployeeCommand command)
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
                return Ok(await _mediator.Send(new GetAllEmployQuery()));
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
                var category = await _mediator.Send(new GetEmployQuery(id));

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
