using MediatR;
using WM.InventoryControl.Domain.Entities;
using WM.InventoryControl.Domain.Interfaces;

namespace WM.InventoryControl.Application.Commands.SaleCommands
{
    public class SaleCommandHandler(IUnitOfWork unitOfWork, IProductService productService) : IRequestHandler<AddSaleCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IProductService _productService = productService;

        public async Task<Guid> Handle(AddSaleCommand request, CancellationToken cancellationToken)
        {
            var quantityTotal = 0;
            var PriceTotal = decimal.Zero;

            foreach (var product in request.Products)
            {
                quantityTotal += product.Quantity;
                PriceTotal += product.Quantity * product.Price;
            }

            var saleId = await _unitOfWork.AddAsync<Sale>(SaleValidator.AddSale(quantityTotal, PriceTotal));

            var saleProducts = new List<SaleProduct>();

            foreach (var product in request.Products)
            {
                saleProducts.Add(SaleValidator.AddSaleProduct(saleId, product.ProductId, product.Quantity));

                var productUpdate = await _productService.GetProductAsync(product.ProductId);

                productUpdate.UpdateQuantityProduct(product.Quantity);
            }

            await _unitOfWork.AddRangeAsync<SaleProduct>(saleProducts);

            await _unitOfWork.SaveChangesAsync();

            return saleId;
        }
    }
}
