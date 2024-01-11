using WM.InventoryControl.Application.Queries.AddressQueries;

namespace WM.InventoryControl.Application.Queries.SupplierQueries
{
    public record SupplierViewModel(Guid Id, string Name, AddressViewModel Address)
    {
    }
}
