using MediatR;

namespace WM.InventoryControl.Application.Queries.PurchaseQueries
{
    public record GetPurchaseQuery(Guid Id) : IRequest<PurchaseViewModel> { }
    public record GetALlPurchaseQuery : IRequest<IEnumerable<PurchaseViewModel>> { }
}
