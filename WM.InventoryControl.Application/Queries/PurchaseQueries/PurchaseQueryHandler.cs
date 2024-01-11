using MediatR;
using WM.InventoryControl.Application.Queries.ProductQueries;
using WM.InventoryControl.Domain.Interfaces;

namespace WM.InventoryControl.Application.Queries.PurchaseQueries
{
    public class PurchaseQueryHandler(IPurchaseService purchaseService) : IRequestHandler<GetPurchaseQuery, PurchaseViewModel>, IRequestHandler<GetALlPurchaseQuery, IEnumerable<PurchaseViewModel>>
    {
        private readonly IPurchaseService _purchaseService = purchaseService;

        public async Task<PurchaseViewModel> Handle(GetPurchaseQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var purchase = await _purchaseService.GetPurchaseAsync(request.Id);

                if (purchase is null) return default!;

                var products = new List<ProductViewModel>();

                foreach (var product in purchase.PurchaseProducts.Where(x => x.PurchaseId.Equals(purchase.Id)).Select(x => x.Product).ToList())
                {
                    products.Add(new ProductViewModel(product.Id, product.Name, product.Quantity, product.Price, null));
                }

                return new PurchaseViewModel(purchase.Id, purchase.Quantity, purchase.Price, purchase.DatePurchase, products);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<PurchaseViewModel>> Handle(GetALlPurchaseQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var purchases = new List<PurchaseViewModel>();

                foreach (var purchase in await _purchaseService.GetAllPurchaseAsync())
                {
                    var products = new List<ProductViewModel>();

                    foreach (var product in purchase.PurchaseProducts.Where(x => x.PurchaseId.Equals(purchase.Id)).Select(x => x.Product).ToList())
                    {
                        products.Add(new ProductViewModel(product.Id, product.Name, product.Quantity, product.Price, null));
                    }

                    purchases.Add(new PurchaseViewModel(purchase.Id, purchase.Quantity, purchase.Price, purchase.DatePurchase, products));
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
