using MediatR;
using WM.InventoryControl.Application.Dtos;

namespace WM.InventoryControl.Application.Queries.ProductQueries
{
    public record GetProductQuery(Guid Id) : IRequest<ProductDto> { }
    public record GetAllProductQuery : IRequest<IEnumerable<ProductDto>> { }
}
