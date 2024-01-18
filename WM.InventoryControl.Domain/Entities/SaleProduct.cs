namespace WM.InventoryControl.Domain.Entities
{
    public class SaleProduct(Guid Id, Guid SaleId, Guid ProductId, int QuantityUnitProduct) : EntityBase(Id)
    {
        public Guid SaleId { get; private set; } = SaleId;
        public Guid ProductId { get; private set; } = ProductId;
        public int QuantityUnitProduct { get; private set; } = QuantityUnitProduct;

        // EF
        public Sale Sale { get; private set; } = default!;
        public Product Product { get; private set; } = default!;
    }
}
