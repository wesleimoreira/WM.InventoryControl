using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WM.InventoryControl.Application.Commands.SaleCommands;
using WM.InventoryControl.Application.Queries.SaleQueries;

namespace WM.InventoryControl.Api.Controllers
{
    [ApiController]
    [Route("v1/sale")]
    [Produces("application/json")]
    [Authorize(Roles = "Admin, Employee")]
    public class SaleController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] AddSaleCommand command)
        {
            try
            {
                var saleId = await _mediator.Send(command);

                return Created(nameof(Get), new { saleId });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            try
            {
                var sale = await _mediator.Send(new GetSaleQuery(id));

                if (sale is null) return NotFound();

                return Ok(sale);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _mediator.Send(new GetAllSaleQuery()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
