using MediatR;

namespace WM.InventoryControl.Application.Commands.SaleCommands
{
    public record AddSaleProductViewModel(Guid ProductId, int Quantity, decimal Price);
    public record AddSaleCommand(IEnumerable<AddSaleProductViewModel> Products) : IRequest<Guid> { }
}
