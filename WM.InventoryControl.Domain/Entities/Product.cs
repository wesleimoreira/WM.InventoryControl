namespace WM.InventoryControl.Domain.Entities
{
    public class Product(Guid Id, string Name, int Quantity, decimal Price, Guid CategoryId, DateTime DateRegistration, DateTime? DateAtualizacao) : EntityBase(Id)
    {
        public string Name { get; private set; } = Name;
        public decimal Price { get; private set; } = Price;
        public int Quantity { get; private set; } = Quantity;
        public Guid CategoryId { get; private set; } = CategoryId;
        public DateTime? DateAtualizacao { get; private set; } = DateAtualizacao;
        public DateTime DateRegistration { get; private set; } = DateRegistration;

        // EF
        public Category Category { get; set; } = default!;
        public IEnumerable<SaleProduct> SaleProducts { get; private set; } = default!;
        public IEnumerable<SupplierProduct> SupplierProducts { get; private set; } = default!;
        public IEnumerable<PurchaseProduct> PurchaseProducts { get; private set; } = default!;

        // Metods   
        public Product UpdateProduct(string name, int quantity, decimal price, Guid categoryId)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
            CategoryId = categoryId;
            DateAtualizacao = DateTime.Now;

            return this;
        }

        public void UpdateQuantityProduct(int quantity)
        {
            Quantity -= quantity;
            DateAtualizacao = DateTime.Now;
        }
    }
}
