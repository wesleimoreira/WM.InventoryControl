using MediatR;
using WM.InventoryControl.Application.Dtos;
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

            if (quantityTotal.Equals(0)) throw new Exception("O Quantity e obrigatório.");

            if (PriceTotal.Equals(decimal.Zero)) throw new Exception("O Preço e Obrigatório");

            var saleId = await _unitOfWork.AddAsync<Sale>(new Sale(Guid.NewGuid(), quantityTotal, PriceTotal, DateTime.Now));

            var saleProducts = await AddSalesProducts(request.Products, saleId);

            await _unitOfWork.AddRangeAsync<SaleProduct>(saleProducts);

            await _unitOfWork.SaveChangesAsync();

            return saleId;
        }


        private async Task<IEnumerable<SaleProduct>> AddSalesProducts(IEnumerable<ProductSalePurchaseDto> products, Guid saleId)
        {
            var saleProducts = new List<SaleProduct>();

            foreach (var product in products)
            {
                if (string.IsNullOrEmpty(saleId.ToString())) throw new Exception("O saleId e obrigatório");

                if (string.IsNullOrEmpty(product.ProductId.ToString())) throw new Exception("O productId e obrigatório");

                if (product.Quantity.Equals(0)) throw new Exception("A Quantidade de produtos deve ser maior que zero.");

                saleProducts.Add(new SaleProduct(Guid.NewGuid(), saleId, product.ProductId, product.Quantity));

                var productUpdate = await _productService.GetProductAsync(product.ProductId);

                productUpdate?.UpdateQuantityProductSale(product.Quantity);
            }

            return saleProducts;
        }
    }
}
