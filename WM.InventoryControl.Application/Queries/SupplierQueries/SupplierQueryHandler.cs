using MediatR;
using WM.InventoryControl.Application.Dtos;
using WM.InventoryControl.Domain.Interfaces;

namespace WM.InventoryControl.Application.Queries.SupplierQueries
{
    public class SupplierQueryHandler(ISupplierService supplierService) : IRequestHandler<GetSupplierQuery, SupplierDto>, IRequestHandler<GetAllSupplierQuery, IEnumerable<SupplierDto>>
    {
        private readonly ISupplierService _supplierServic = supplierService;

        public async Task<SupplierDto> Handle(GetSupplierQuery request, CancellationToken cancellationToken)
        {
            var supplier = await _supplierServic.GetSupplierAsync(request.Id);

            if (supplier is null) return default!;

            var ProductsList = new List<ProductDto>();

            foreach (var product in supplier.SupplierProducts.Where(x => x.SupplierId == supplier.Id).Select(x => x.Product).ToList())
            {
                ProductsList.Add(new ProductDto(product.Id, product.Name, product.Quantity, product.Price, null));
            }

            return new SupplierDto(supplier.Id, supplier.Name,
                new AddressDto(supplier.Address.Id,
                supplier.Address.Country,
                supplier.Address.State,
                supplier.Address.City,
                supplier.Address.District,
                supplier.Address.Street,
                supplier.Address.ZipCode),
                ProductsList);
        }

        public async Task<IEnumerable<SupplierDto>> Handle(GetAllSupplierQuery request, CancellationToken cancellationToken)
        {
            var suppliersList = new List<SupplierDto>();

            foreach (var supplier in await _supplierServic.GetAllSuppliers())
            {
                var ProductsList = new List<ProductDto>();

                foreach (var product in supplier.SupplierProducts.Where(x => x.SupplierId == supplier.Id).Select(x => x.Product).ToList())
                {
                    ProductsList.Add(new ProductDto(product.Id, product.Name, product.Quantity, product.Price, null));
                }

                suppliersList.Add(new SupplierDto(supplier.Id, supplier.Name,
                           new AddressDto(
                               supplier.Address.Id,
                               supplier.Address.Country,
                               supplier.Address.State,
                               supplier.Address.City,
                               supplier.Address.District,
                               supplier.Address.Street,
                               supplier.Address.ZipCode),
                               ProductsList));
            }

            return suppliersList;
        }
    }
}
