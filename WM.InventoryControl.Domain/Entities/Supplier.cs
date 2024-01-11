namespace WM.InventoryControl.Domain.Entities
{
    public class Supplier(Guid Id, string Name, Guid AddressId) : EntityBase(Id)
    {
        public string Name { get; private set; } = Name;
        public Guid AddressId { get; private set; } = AddressId;

        // EF
        public Address Address { get; private set; } = default!;
        public IEnumerable<SupplierProduct> SupplierProducts { get; private set; } = default!;
    }
}
