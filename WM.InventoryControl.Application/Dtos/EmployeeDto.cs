namespace WM.InventoryControl.Application.Dtos
{
    public record EmployeeDto(Guid Id, string Name, CompanyDto Company, AddressDto Address)
    {
    }
}
