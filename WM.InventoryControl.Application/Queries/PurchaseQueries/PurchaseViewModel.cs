using WM.InventoryControl.Application.Queries.ProductQueries;

namespace WM.InventoryControl.Application.Queries.PurchaseQueries
{
    public record PurchaseViewModel(Guid Id, int Quantity, decimal Price, DateTime DatePurchase, IEnumerable<ProductViewModel> Products) { }
}
