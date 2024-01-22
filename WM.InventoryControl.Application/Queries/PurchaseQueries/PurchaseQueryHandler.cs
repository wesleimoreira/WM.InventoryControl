using MediatR;
using WM.InventoryControl.Application.Dtos;
using WM.InventoryControl.Domain.Interfaces;

namespace WM.InventoryControl.Application.Queries.PurchaseQueries
{
    public class PurchaseQueryHandler(IPurchaseService purchaseService) : IRequestHandler<GetPurchaseQuery, PurchaseDto>, IRequestHandler<GetALlPurchaseQuery, IEnumerable<PurchaseDto>>
    {
        private readonly IPurchaseService _purchaseService = purchaseService;

        public async Task<PurchaseDto> Handle(GetPurchaseQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var purchase = await _purchaseService.GetPurchaseAsync(request.Id);

                if (purchase is null) return default!;

                var products = new List<ProductDto>();

                foreach (var product in purchase.PurchaseProducts.Where(x => x.PurchaseId.Equals(purchase.Id)).Select(x => x.Product).ToList())
                {
                    products.Add(new ProductDto(product.Id, product.Name, product.Quantity, product.Price, null));
                }

                return new PurchaseDto(purchase.Id, purchase.Quantity, purchase.Price, purchase.DatePurchase, products);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<PurchaseDto>> Handle(GetALlPurchaseQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var purchases = new List<PurchaseDto>();

                foreach (var purchase in await _purchaseService.GetAllPurchaseAsync())
                {
                    var products = new List<ProductDto>();

                    foreach (var product in purchase.PurchaseProducts.Where(x => x.PurchaseId.Equals(purchase.Id)).Select(x => x.Product).ToList())
                    {
                        products.Add(new ProductDto(product.Id, product.Name, product.Quantity, product.Price, null));
                    }

                    purchases.Add(new PurchaseDto(purchase.Id, purchase.Quantity, purchase.Price, purchase.DatePurchase, products));
                }

                return purchases;
            }
            catch
            {
                throw;
            }
        }
    }
}
