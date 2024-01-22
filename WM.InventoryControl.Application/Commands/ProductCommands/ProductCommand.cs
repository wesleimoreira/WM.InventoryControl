using MediatR;

namespace WM.InventoryControl.Application.Commands.ProductCommands
{
    public record AddProductCommand(string Name, int Quantity, decimal Price, Guid CategoryId, Guid SupplierId) : IRequest<Guid> { }

    public record UpdateProductCommand(Guid Id, string Name, int Quantity, decimal Price, Guid CategoryId) : IRequest { }

    public record DeleteProductCommand(Guid Id, string Name, int Quantity, decimal Price, Guid CategoryId) : IRequest { }
}
