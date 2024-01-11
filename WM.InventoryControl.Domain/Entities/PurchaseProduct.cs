namespace WM.InventoryControl.Domain.Entities
{
    public class PurchaseProduct(Guid Id, Guid ProductId, Guid PurchaseId) : EntityBase(Id)
    {
        public Guid ProductId { get; private set; } = ProductId;
        public Guid PurchaseId { get; private set; } = PurchaseId;

        public Product Product { get; private set; } = default!;
        public Purchase Purchase { get; private set; } = default!;
    }
}
