using MediatR;
using Microsoft.AspNetCore.Mvc;
using WM.InventoryControl.Application.Commands.SupplierCommands;
using WM.InventoryControl.Application.Queries.SupplierQueries;

namespace WM.InventoryControl.Api.Controllers
{
    [ApiController]
    [Route("v1/supplier")]
    public class SupplierController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddSupplierCommand command)
        {
            try
            {
                var supplierId = await _mediator.Send(command);

                return Created(nameof(Get), new { supplierId });
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
                return Ok(await _mediator.Send(new GetAllSupplierQuery()));
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
                var category = await _mediator.Send(new GetSupplierQuery(id));

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
