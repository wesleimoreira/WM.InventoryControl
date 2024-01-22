using MediatR;
using WM.InventoryControl.Application.Dtos;

namespace WM.InventoryControl.Application.Queries.SaleQueries
{
    public record GetSaleQuery(Guid Id) : IRequest<SaleDto> { }
    public record GetAllSaleQuery() : IRequest<IEnumerable<SaleDto>> { }
}
