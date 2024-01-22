namespace WM.InventoryControl.Application.Dtos
{
    public record SupplierDto(Guid Id, string Name, AddressDto Address, IEnumerable<ProductDto> Products)
    {
    }
}
