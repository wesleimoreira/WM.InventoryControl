using MediatR;
using WM.InventoryControl.Application.Dtos;
using WM.InventoryControl.Domain.Interfaces;

namespace WM.InventoryControl.Application.Queries.ProductQueries
{
    public class ProductQueryHandler(IProductService productService) : IRequestHandler<GetAllProductQuery, IEnumerable<ProductDto>>, IRequestHandler<GetProductQuery, ProductDto>
    {
        private readonly IProductService _productService = productService;

        public async Task<IEnumerable<ProductDto>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            return (from product in await _productService.GetAllProductAsync()
                    select new ProductDto(product.Id, product.Name, product.Quantity, product.Price,
                           new CategoryDto(product.Category.Id, product.Category.Name))).ToList();
        }

        public async Task<ProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _productService.GetProductAsync(request.Id);

            if (product is null) return default!;

            return new ProductDto(product.Id, product.Name, product.Quantity, product.Price,
                           new CategoryDto(product.Category.Id, product.Category.Name));
        }
    }
}
