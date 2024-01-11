using MediatR;
using WM.InventoryControl.Application.Commands.AddressCommands;

namespace WM.InventoryControl.Application.Commands.SupplierCommands
{
    public record AddSupplierCommand(string Name, AddressCommand Address) : IRequest<Guid> { }
}
