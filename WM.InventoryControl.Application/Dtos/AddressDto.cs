namespace WM.InventoryControl.Application.Dtos
{
    public record AddressDto(Guid Id, string Country, string State, string City, string District, string Street, string ZipCode) { }
}
