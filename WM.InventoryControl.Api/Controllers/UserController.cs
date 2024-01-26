using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WM.InventoryControl.Application.Commands.UserCommands;

namespace WM.InventoryControl.Api.Controllers
{   
    [ApiController]
    [Route("v1/user")]
    [Produces("application/json")]
    public class UserController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        
        [HttpPost("/login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostLogin(AddLoginCommand command)
        {
            try
            {
                var token = await _mediator.Send(command);

                if (string.IsNullOrEmpty(token))
                    return NotFound("Usuario/Senha não confere!");

                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("/register")]
        [Authorize(Roles = "Admin, Employee")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostRegister(AddUserCommand command)
        {
            try
            {
                var userId = await _mediator.Send(command);

                if (Guid.Empty.Equals(userId))
                    return NotFound("O email não foi encontrado em nossa base de dados!");

                return Created(nameof(PostLogin), new { command });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
