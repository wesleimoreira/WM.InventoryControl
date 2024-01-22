using MediatR;
using WM.InventoryControl.Application.Validators;
using WM.InventoryControl.Domain.Entities;
using WM.InventoryControl.Domain.Interfaces;

namespace WM.InventoryControl.Application.Commands.ProductCommands
{
    public class ProductCommandHandler(IUnitOfWork unitOfWork, IProductService productService) : IRequestHandler<AddProductCommand, Guid>, IRequestHandler<UpdateProductCommand>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IProductService _productService = productService;

        public async Task<Guid> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = ProductValidator.AddProduct(request.Name, request.Quantity, request.Price, request.CategoryId);

            var productId = await _unitOfWork.AddAsync<Product>(product);

            await _unitOfWork.SaveChangesAsync();

            return productId;
        }

        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productService.GetProductAsync(request.Id);

            product.UpdateProduct(request.Name, request.Quantity, request.Price, request.CategoryId);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
