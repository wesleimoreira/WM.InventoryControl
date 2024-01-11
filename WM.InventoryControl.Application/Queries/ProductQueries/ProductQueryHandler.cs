using MediatR;
using WM.InventoryControl.Application.Queries.CategoryQueries;
using WM.InventoryControl.Domain.Interfaces;

namespace WM.InventoryControl.Application.Queries.ProductQueries
{
    public class ProductQueryHandler(IProductService productService) : IRequestHandler<GetAllProductQuery, IEnumerable<ProductViewModel>>, IRequestHandler<GetProductQuery, ProductViewModel>
    {
        private readonly IProductService _productService = productService;

        public async Task<IEnumerable<ProductViewModel>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return (from product in await _productService.GetAllProductAsync()
                        select new ProductViewModel(product.Id, product.Name, product.Quantity, product.Price,
                               new CategoryViewModel(product.Category.Id, product.Category.Name))).ToList();
            }
            catch
            {
                throw;
            }
        }

        public async Task<ProductViewModel> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var product = await _productService.GetProductAsync(request.Id);

                if (product is null) return default!;

                return new ProductViewModel(product.Id, product.Name, product.Quantity, product.Price,
                               new CategoryViewModel(product.Category.Id, product.Category.Name));
            }
            catch
            {
                throw;
            }
        }
    }
}
