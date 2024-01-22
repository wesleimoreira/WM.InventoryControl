using MediatR;
using WM.InventoryControl.Application.Dtos;

namespace WM.InventoryControl.Application.Commands.SaleCommands
{
    public record AddSaleCommand(IEnumerable<ProductSalePurchaseDto> Products) : IRequest<Guid> { }
}
