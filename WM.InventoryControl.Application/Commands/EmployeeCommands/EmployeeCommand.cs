using MediatR;
using WM.InventoryControl.Application.Commands.AddressCommands;

namespace WM.InventoryControl.Application.Commands.EmployeeCommands
{
    public record AddEmployeeCommand(string Name, Guid CompanyId, AddressCommand Address) : IRequest<Guid> { }
}
