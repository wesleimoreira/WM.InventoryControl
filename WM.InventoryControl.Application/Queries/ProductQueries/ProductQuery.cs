using MediatR;

namespace WM.InventoryControl.Application.Queries.ProductQueries
{
    public record GetProductQuery(Guid Id) : IRequest<ProductViewModel> { }
    public record GetAllProductQuery : IRequest<IEnumerable<ProductViewModel>> { }
}
