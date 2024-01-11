namespace WM.InventoryControl.Domain.Entities
{
    public class Company(Guid Id, string Name, Guid AddressId) : EntityBase(Id)
    {
        public string Name { get; private set; } = Name;
        public Guid AddressId { get; private set; } = AddressId;

        // EF
        public Address Address { get; private set; } = default!;
        public IEnumerable<Employee> Employees { get; private set; } = default!;
    }
}
