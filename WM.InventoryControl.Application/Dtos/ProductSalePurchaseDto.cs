namespace WM.InventoryControl.Application.Dtos
{
    public record ProductSalePurchaseDto(Guid ProductId, int Quantity, decimal Price) { }
}
