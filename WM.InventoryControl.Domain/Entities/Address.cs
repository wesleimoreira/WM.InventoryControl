namespace WM.InventoryControl.Domain.Entities
{
    public class Address(Guid Id, string Country, string State, string City, string District, string Street, string ZipCode) : EntityBase(Id)
    {
        public string Country { get; set; } = Country;
        public string State { get; set; } = State;
        public string City { get; set; } = City;
        public string District { get; set; } = District;
        public string Street { get; set; } = Street;
        public string ZipCode { get; set; } = ZipCode;

        // EF
        public Company Company { get; set; } = default!;
        public Employee Employee { get; set; } = default!;
        public Supplier Supplier { get; set; } = default!;
    }
}
