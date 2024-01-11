using MediatR;
using WM.InventoryControl.Application.Commands.AddressCommands;

namespace WM.InventoryControl.Application.Commands.CompanyCommands
{
    public record AddCompanyCommand(string Name, AddressCommand Address) : IRequest<Guid>
    { }
}
