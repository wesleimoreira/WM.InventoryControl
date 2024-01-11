using MediatR;

namespace WM.InventoryControl.Application.Commands.PurchaseCommands
{
    public record ADDPurchaseCommand(int Quantity, decimal Price, IEnumerable<Guid> Products) : IRequest<Guid>
    {
    }
}
