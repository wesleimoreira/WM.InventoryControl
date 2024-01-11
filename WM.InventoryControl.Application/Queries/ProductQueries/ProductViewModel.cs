using WM.InventoryControl.Application.Queries.CategoryQueries;

namespace WM.InventoryControl.Application.Queries.ProductQueries
{
    public record ProductViewModel(Guid Id, string Name, int Quantity, decimal Price, CategoryViewModel? Category) { }
}
