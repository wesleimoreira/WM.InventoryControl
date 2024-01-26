using MediatR;
using Microsoft.AspNetCore.Mvc;
using WM.InventoryControl.Application.Commands.ProductCommands;
using WM.InventoryControl.Application.Queries.ProductQueries;

namespace WM.InventoryControl.Api.Controllers
{
    [ApiController]
    [Route("v1/product")]
    public class ProductController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]   
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] AddProductCommand command)
        {
            try
            {
                var productId = await _mediator.Send(command);

                return Created(nameof(Get), new { productId });
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
                return Ok(await _mediator.Send(new GetAllProductQuery()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]       
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            try
            {
                return Ok(await _mediator.Send(new GetProductQuery(id)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
