using WM.InventoryControl.Application.Queries.AddressQueries;
using WM.InventoryControl.Application.Queries.CompanyQueries;

namespace WM.InventoryControl.Application.Queries.EmployeeQueries
{
    public record EmployeeViewModel(Guid Id, string Name, CompanyViewModel Company, AddressViewModel Address)
    {
    }
}
