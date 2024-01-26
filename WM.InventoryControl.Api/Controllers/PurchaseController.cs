using MediatR;
using Microsoft.AspNetCore.Mvc;
using WM.InventoryControl.Application.Commands.PurchaseCommands;
using WM.InventoryControl.Application.Queries.PurchaseQueries;

namespace WM.InventoryControl.Api.Controllers
{
    [ApiController]
    [Route("v1/purchase")]
    public class PurchaseController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]       
        [ProducesResponseType(StatusCodes.Status201Created)]     
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] ADDPurchaseCommand command)
        {
            try
            {
                var PurchaseId = await _mediator.Send(command);

                return Created(nameof(Get), new { PurchaseId });
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
                var Purchase = await _mediator.Send(new GetPurchaseQuery(id));

                if (Purchase is null) return NotFound();

                return Ok(Purchase);
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
                return Ok(await _mediator.Send(new GetALlPurchaseQuery()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
