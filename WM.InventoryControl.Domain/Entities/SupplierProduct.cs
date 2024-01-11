namespace WM.InventoryControl.Domain.Entities
{
    public class SupplierProduct(Guid Id, Guid ProductId, Guid SupplierId) : EntityBase(Id)
    {
        public Guid ProductId { get; private set; } = ProductId;
        public Guid SupplierId { get; private set; } = SupplierId;

        // EF
        public Product Product { get; private set; } = default!;
        public Supplier Supplier { get; private set; } = default!;
    }
}
