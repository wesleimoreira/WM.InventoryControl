using MediatR;

namespace WM.InventoryControl.Application.Commands.AddressCommands
{
    public record AddressCommand(string Country, string State, string City, string District, string Street, string ZipCode) : IRequest<Guid> { }

}
