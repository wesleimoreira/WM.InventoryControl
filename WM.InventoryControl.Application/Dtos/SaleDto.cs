namespace WM.InventoryControl.Application.Dtos
{
    public record SaleDto(Guid Id, int Quantity, decimal Price, DateTime DateSale, IEnumerable<ProductDto> Products) { }
}
