using MediatR;
using WM.InventoryControl.Application.Queries.ProductQueries;
using WM.InventoryControl.Domain.Interfaces;

namespace WM.InventoryControl.Application.Queries.SaleQueries
{
    public class SaleQueryHandler(ISaleService saleService) : IRequestHandler<GetSaleQuery, SaleViewModel>, IRequestHandler<GetAllSaleQuery, IEnumerable<SaleViewModel>>
    {
        private readonly ISaleService _saleService = saleService;

        public async Task<SaleViewModel> Handle(GetSaleQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var sale = await _saleService.GetSaleAsync(request.Id);

                if (sale is null) return default!;

                var products = new List<ProductViewModel>();

                foreach (var product in sale.SaleProducts.Where(x => x.SaleId == sale.Id).Select(x => x.Product).ToList())
                {
                    products.Add(new ProductViewModel(product.Id, product.Name, product.Quantity, product.Price, null));
                }

                return new SaleViewModel(sale.Id, sale.Quantity, sale.Price, sale.DateSale, products);
            }
            catch
            {

                throw;
            }
        }

        public async Task<IEnumerable<SaleViewModel>> Handle(GetAllSaleQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var sales = new List<SaleViewModel>();

                foreach (var sale in await _saleService.GetAllSalesAsync())
                {
                    var products = new List<ProductViewModel>();

                    foreach (var product in sale.SaleProducts.Where(x => x.SaleId == sale.Id).Select(x => x.Product).ToList())
                    {
                        products.Add(new ProductViewModel(product.Id, product.Name, product.Quantity, product.Price, null));
                    }

                    sales.Add(new SaleViewModel(sale.Id, sale.Quantity, sale.Price, sale.DateSale, products));
                }

                return sales;
            }
            catch
            {

                throw;
            }
        }
    }
}
