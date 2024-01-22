using MediatR;
using WM.InventoryControl.Application.Dtos;

namespace WM.InventoryControl.Application.Queries.PurchaseQueries
{
    public record GetPurchaseQuery(Guid Id) : IRequest<PurchaseDto> { }
    public record GetALlPurchaseQuery : IRequest<IEnumerable<PurchaseDto>> { }
}
