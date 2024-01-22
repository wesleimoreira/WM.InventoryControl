namespace WM.InventoryControl.Application.Dtos
{
    public record CompanyDto(Guid Id, string Name, AddressDto? Address)
    {
    }
}
