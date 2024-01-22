namespace WM.InventoryControl.Application.Dtos
{
    public record PurchaseDto(Guid Id, int Quantity, decimal Price, DateTime DatePurchase, IEnumerable<ProductDto> Products) { }
}
