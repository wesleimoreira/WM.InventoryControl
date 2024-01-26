using MediatR;
using Microsoft.AspNetCore.Mvc;
using WM.InventoryControl.Application.Commands.UserCommands;
using WM.InventoryControl.Application.Queries.AuthQueries;

namespace WM.InventoryControl.Api.Controllers
{
    [ApiController]
    [Route("v1/user")]
    [Produces("application/json")]
    public class UserController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(UserQuery query)
        {
            try
            {
                return Ok(await _mediator.Send(query));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(AddUserCommand command)
        {
            try
            {
                var userId = await _mediator.Send(command);

                return Created(nameof(Get), new { userId });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
