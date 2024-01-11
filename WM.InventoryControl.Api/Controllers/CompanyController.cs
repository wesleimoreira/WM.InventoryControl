using MediatR;
using Microsoft.AspNetCore.Mvc;
using WM.InventoryControl.Application.Commands.CompanyCommands;
using WM.InventoryControl.Application.Queries.CompanyQueries;

namespace WM.InventoryControl.Api.Controllers
{
    [ApiController]
    [Route("v1/company")]
    public class CompanyController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddCompanyCommand command)
        {
            try
            {
                var companyId = await _mediator.Send(command);

                return Created(nameof(Get), new { companyId });
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
                var companyId = await _mediator.Send(new GetCompanyQuery(id));

                if (companyId is null) return NotFound();

                return Ok(companyId);
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
                return Ok(await _mediator.Send(new GetAllCompanyQuery()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
