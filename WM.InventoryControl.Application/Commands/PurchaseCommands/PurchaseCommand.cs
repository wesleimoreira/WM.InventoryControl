using MediatR;
using WM.InventoryControl.Application.Dtos;

namespace WM.InventoryControl.Application.Commands.PurchaseCommands
{
    public record ADDPurchaseCommand(IEnumerable<ProductSalePurchaseDto> Products) : IRequest<Guid>
    {
    }
}
