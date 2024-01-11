namespace WM.InventoryControl.Domain.Entities
{
    public class Sale(Guid Id, int Quantity, decimal Price, DateTime DateSale) : EntityBase(Id)
    {
        public decimal Price { get; private set; } = Price;
        public int Quantity { get; private set; } = Quantity;
        public DateTime DateSale { get; private set; } = DateSale;

        // EF
        public IEnumerable<SaleProduct> SaleProducts { get; private set; } = default!;
    }
}
