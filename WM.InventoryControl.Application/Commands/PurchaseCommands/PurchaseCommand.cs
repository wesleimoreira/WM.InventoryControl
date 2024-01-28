using MediatR;
using WM.InventoryControl.Application.Dtos;

namespace WM.InventoryControl.Application.Commands.PurchaseCommands
{
    public record AddPurchaseCommand(IEnumerable<ProductSalePurchaseDto> Products) : IRequest<Guid> { }
}
