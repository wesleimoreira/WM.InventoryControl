using MediatR;
using Microsoft.AspNetCore.Mvc;
using WM.InventoryControl.Application.Commands.SaleCommands;
using WM.InventoryControl.Application.Queries.SaleQueries;

namespace WM.InventoryControl.Api.Controllers
{
    [ApiController]
    [Route("v1/sale")]
    public class SaleController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
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
