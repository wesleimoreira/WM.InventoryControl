namespace WM.InventoryControl.Domain.Entities
{
    public class SaleProduct(Guid Id, Guid SaleId, Guid ProductId) : EntityBase(Id)
    {
        public Guid SaleId { get; private set; } = SaleId;
        public Guid ProductId { get; private set; } = ProductId;

        // EF
        public Sale Sale { get; private set; } = default!;
        public Product Product { get; private set; } = default!;
    }
}
