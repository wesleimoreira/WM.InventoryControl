using WM.InventoryControl.Application.Queries.ProductQueries;

namespace WM.InventoryControl.Application.Queries.SaleQueries
{
    public record SaleViewModel(Guid Id, int Quantity, decimal Price, DateTime DateSale, IEnumerable<ProductViewModel> Products) { }
}
