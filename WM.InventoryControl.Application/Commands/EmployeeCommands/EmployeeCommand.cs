using MediatR;
using WM.InventoryControl.Application.Commands.AddressCommands;

namespace WM.InventoryControl.Application.Commands.EmployeeCommands
{
    public record AddEmployeeCommand(string Name, string Email, Guid CompanyId, AddressCommand Address) : IRequest<Guid> { }
}
