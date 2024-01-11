using MediatR;

namespace WM.InventoryControl.Application.Queries.SaleQueries
{
    public record GetSaleQuery(Guid Id) : IRequest<SaleViewModel> { }
    public record GetAllSaleQuery() : IRequest<IEnumerable<SaleViewModel>> { }
}
