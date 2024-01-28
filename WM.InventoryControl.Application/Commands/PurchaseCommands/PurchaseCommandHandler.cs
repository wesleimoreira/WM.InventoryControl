using MediatR;
using WM.InventoryControl.Application.Dtos;
using WM.InventoryControl.Domain.Entities;
using WM.InventoryControl.Domain.Interfaces;

namespace WM.InventoryControl.Application.Commands.PurchaseCommands
{
    public class PurchaseCommandHandler(IUnitOfWork unitOfWork, IProductService productService) : IRequestHandler<AddPurchaseCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IProductService _productService = productService;

        public async Task<Guid> Handle(AddPurchaseCommand request, CancellationToken cancellationToken)
        {
            var quantityTotal = 0;
            var PriceTotal = decimal.Zero;

            foreach (var product in request.Products)
            {
                quantityTotal += product.Quantity;
                PriceTotal += product.Quantity * product.Price;
            }

            if (quantityTotal.Equals(0)) throw new Exception("O Quantity e obrigatório.");

            if (PriceTotal.Equals(decimal.Zero)) throw new Exception("O Preço e Obrigatório");

            var purchaseId = await _unitOfWork.AddAsync<Purchase>(new Purchase(Guid.NewGuid(), quantityTotal, PriceTotal, DateTime.UtcNow));

            var purchaseProducts = await AddPurchaseProduct(request.Products, purchaseId);

            await _unitOfWork.AddRangeAsync<PurchaseProduct>(purchaseProducts);

            await _unitOfWork.SaveChangesAsync();

            return purchaseId;
        }

        private async Task<IEnumerable<PurchaseProduct>> AddPurchaseProduct(IEnumerable<ProductSalePurchaseDto> products, Guid purchaseId)
        {
            var purchaseProducts = new List<PurchaseProduct>();

            foreach (var product in products)
            {
                if (string.IsNullOrEmpty(purchaseId.ToString())) throw new Exception("O purchaseId e obrigatório");

                if (string.IsNullOrEmpty(product.ToString())) throw new Exception("O productId e obrigatório");

                if (product.Quantity.Equals(0)) throw new Exception("A Quantidade de produtos deve ser maior que zero.");

                purchaseProducts.Add(new PurchaseProduct(Guid.NewGuid(), purchaseId, product.ProductId, product.Quantity));

                var productUpdate = await _productService.GetProductAsync(product.ProductId);

                productUpdate.UpdateQuantityProductPurchase(product.Quantity);
            }

            return purchaseProducts;
        }
    }
}
