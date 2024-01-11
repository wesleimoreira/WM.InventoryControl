using MediatR;

namespace WM.InventoryControl.Application.Queries.CategoryQueries
{
    public record GetCategoryQuery(Guid Id) : IRequest<CategoryViewModel> { }
    public record GetAllCategoryQuery : IRequest<IEnumerable<CategoryViewModel>> { }
}
