using MediatR;
using WM.InventoryControl.Application.Validators;
using WM.InventoryControl.Domain.Entities;
using WM.InventoryControl.Domain.Interfaces;

namespace WM.InventoryControl.Application.Commands.PurchaseCommands
{
    public class PurchaseCommandHandler(IUnitOfWork unitOfWork, IProductService productService) : IRequestHandler<ADDPurchaseCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IProductService _productService = productService;

        public async Task<Guid> Handle(ADDPurchaseCommand request, CancellationToken cancellationToken)
        {
            var quantityTotal = 0;
            var PriceTotal = decimal.Zero;

            foreach (var product in request.Products)
            {
                quantityTotal += product.Quantity;
                PriceTotal += product.Quantity * product.Price;
            }

            var purchaseId = await _unitOfWork.AddAsync<Purchase>(PurchaseValidator.AddPurchase(quantityTotal, PriceTotal));

            var purchaseProducts = new List<PurchaseProduct>();

            foreach (var product in request.Products)
            {
                purchaseProducts.Add(PurchaseValidator.AddPurchaseProduct(purchaseId, product.ProductId, product.Quantity));

                var productUpdate = await _productService.GetProductAsync(product.ProductId);

                productUpdate.UpdateQuantityProductPurchase(product.Quantity);
            }

            await _unitOfWork.AddRangeAsync<PurchaseProduct>(purchaseProducts);

            await _unitOfWork.SaveChangesAsync();

            return purchaseId;
        }
    }
}
