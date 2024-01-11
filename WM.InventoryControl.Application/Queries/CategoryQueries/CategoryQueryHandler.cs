using MediatR;
using WM.InventoryControl.Domain.Interfaces;

namespace WM.InventoryControl.Application.Queries.CategoryQueries
{
    public class CategoryQueryHandler(ICategoryService categoryService) : IRequestHandler<GetAllCategoryQuery, IEnumerable<CategoryViewModel>>, IRequestHandler<GetCategoryQuery, CategoryViewModel>
    {
        private readonly ICategoryService _categoryService = categoryService;

        public async Task<IEnumerable<CategoryViewModel>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return (from category in await _categoryService.GetAllCategoriesAsync()
                        select new CategoryViewModel(category.Id, category.Name)).ToList();
            }
            catch
            {
                throw;
            }
        }

        public async Task<CategoryViewModel> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var category = await _categoryService.GetCategoryAsync(request.Id);

                if (category is null) return default!;

                return new CategoryViewModel(category.Id, category.Name);
            }
            catch
            {
                throw;
            }
        }
    }
}
