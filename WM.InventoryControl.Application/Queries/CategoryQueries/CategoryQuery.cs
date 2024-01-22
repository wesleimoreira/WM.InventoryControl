using MediatR;
using WM.InventoryControl.Application.Dtos;

namespace WM.InventoryControl.Application.Queries.CategoryQueries
{
    public record GetCategoryQuery(Guid Id) : IRequest<CategoryDto> { }
    public record GetAllCategoryQuery : IRequest<IEnumerable<CategoryDto>> { }
}
