using MediatR;
using WM.InventoryControl.Application.Dtos;
using WM.InventoryControl.Domain.Interfaces;

namespace WM.InventoryControl.Application.Queries.SaleQueries
{
    public class SaleQueryHandler(ISaleService saleService) : IRequestHandler<GetSaleQuery, SaleDto>, IRequestHandler<GetAllSaleQuery, IEnumerable<SaleDto>>
    {
        private readonly ISaleService _saleService = saleService;

        public async Task<SaleDto> Handle(GetSaleQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var sale = await _saleService.GetSaleAsync(request.Id);

                if (sale is null) return default!;

                var products = new List<ProductDto>();

                foreach (var product in sale.SaleProducts.Where(x => x.SaleId == sale.Id).Select(x => x.Product).ToList())
                {
                    products.Add(new ProductDto(product.Id, product.Name, product.Quantity, product.Price, null));
                }

                return new SaleDto(sale.Id, sale.Quantity, sale.Price, sale.DateSale, products);
            }
            catch
            {

                throw;
            }
        }

        public async Task<IEnumerable<SaleDto>> Handle(GetAllSaleQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var sales = new List<SaleDto>();

                foreach (var sale in await _saleService.GetAllSalesAsync())
                {
                    var products = new List<ProductDto>();

                    foreach (var product in sale.SaleProducts.Where(x => x.SaleId == sale.Id).Select(x => x.Product).ToList())
                    {
                        products.Add(new ProductDto(product.Id, product.Name, product.Quantity, product.Price, null));
                    }

                    sales.Add(new SaleDto(sale.Id, sale.Quantity, sale.Price, sale.DateSale, products));
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
