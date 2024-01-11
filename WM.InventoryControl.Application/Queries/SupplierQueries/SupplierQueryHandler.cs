using MediatR;
using WM.InventoryControl.Application.Queries.AddressQueries;
using WM.InventoryControl.Domain.Interfaces;

namespace WM.InventoryControl.Application.Queries.SupplierQueries
{
    public class SupplierQueryHandler(ISupplierService supplierService) : IRequestHandler<GetSupplierQuery, SupplierViewModel>, IRequestHandler<GetAllSupplierQuery, IEnumerable<SupplierViewModel>>
    {
        private readonly ISupplierService _supplierServic = supplierService;

        public async Task<SupplierViewModel> Handle(GetSupplierQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var supplier = await _supplierServic.GetSupplierAsync(request.Id);

                if (supplier is null) return default!;

                return new SupplierViewModel(supplier.Id, supplier.Name,
                    new AddressViewModel(
                        supplier.Address.Id,
                        supplier.Address.Country,
                        supplier.Address.State,
                        supplier.Address.City,
                        supplier.Address.District,
                        supplier.Address.Street,
                        supplier.Address.ZipCode));
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<SupplierViewModel>> Handle(GetAllSupplierQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return (from supplier in await _supplierServic.GetAllSuppliers()
                        select new SupplierViewModel(supplier.Id, supplier.Name,
                               new AddressViewModel(
                                    supplier.Address.Id,
                                    supplier.Address.Country,
                                    supplier.Address.State,
                                    supplier.Address.City,
                                    supplier.Address.District,
                                    supplier.Address.Street,
                                    supplier.Address.ZipCode))).ToList();
            }
            catch
            {
                throw;
            }
        }
    }
}
