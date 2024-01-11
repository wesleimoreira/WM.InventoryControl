
namespace WM.InventoryControl.Domain.Entities
{
    public class Product(Guid Id, string Name, int Quantity, decimal Price, Guid CategoryId) : EntityBase(Id)
    {
        public string Name { get; private set; } = Name;
        public decimal Price { get; private set; } = Price;
        public int Quantity { get; private set; } = Quantity;
        public Guid CategoryId { get; private set; } = CategoryId;
        public DateTime RegistrationDate { get; private set; } = DateTime.Now;

        // EF
        public Category Category { get; set; } = default!;
        public IEnumerable<SaleProduct> SaleProducts { get; private set; } = default!;
        public IEnumerable<SupplierProduct> SupplierProducts { get; private set; } = default!;
        public IEnumerable<PurchaseProduct> PurchaseProducts { get; private set; } = default!;
    }
}
