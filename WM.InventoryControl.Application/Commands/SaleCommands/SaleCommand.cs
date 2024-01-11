using MediatR;

namespace WM.InventoryControl.Application.Commands.SaleCommands
{
    public record AddSaleCommand(int Quantity, decimal Price,IEnumerable<Guid> Products) : IRequest<Guid> { }
}
