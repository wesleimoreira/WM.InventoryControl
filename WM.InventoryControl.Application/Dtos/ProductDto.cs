namespace WM.InventoryControl.Application.Dtos
{
    public record ProductDto(Guid Id, string Name, int Quantity, decimal Price, CategoryDto? Category) { }
}
