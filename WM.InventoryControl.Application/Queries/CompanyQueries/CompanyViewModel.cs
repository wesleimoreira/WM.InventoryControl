using WM.InventoryControl.Application.Queries.AddressQueries;

namespace WM.InventoryControl.Application.Queries.CompanyQueries
{
    public record CompanyViewModel(Guid Id, string Name, AddressViewModel? Address)
    {
    }
}
