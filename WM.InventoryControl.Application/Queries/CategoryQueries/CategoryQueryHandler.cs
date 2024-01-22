using MediatR;
using WM.InventoryControl.Application.Dtos;
using WM.InventoryControl.Domain.Interfaces;

namespace WM.InventoryControl.Application.Queries.CategoryQueries
{
    public class CategoryQueryHandler(ICategoryService categoryService) : IRequestHandler<GetAllCategoryQuery, IEnumerable<CategoryDto>>, IRequestHandler<GetCategoryQuery, CategoryDto>
    {
        private readonly ICategoryService _categoryService = categoryService;

        public async Task<IEnumerable<CategoryDto>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            return (from category in await _categoryService.GetAllCategoriesAsync()
                    select new CategoryDto(category.Id, category.Name)).ToList();
        }

        public async Task<CategoryDto> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryService.GetCategoryAsync(request.Id);

            if (category is null) return default!;

            return new CategoryDto(category.Id, category.Name);
        }
    }
}
