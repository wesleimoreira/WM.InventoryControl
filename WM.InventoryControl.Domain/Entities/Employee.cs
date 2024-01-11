namespace WM.InventoryControl.Domain.Entities
{
    public class Employee(Guid Id, string Name, Guid CompanyId, Guid AddressId) : EntityBase(Id)
    {
        public string Name { get; private set; } = Name;
        public Guid AddressId { get; private set; } = AddressId;
        public Guid CompanyId { get; private set; } = CompanyId;

        // EF
        public Address Address { get; private set; } = default!;
        public Company Company { get; private set; } = default!;
    }
}
