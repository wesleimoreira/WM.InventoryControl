namespace WM.InventoryControl.Domain.Entities
{
    public class Category(Guid Id, string Name) : EntityBase(Id)
    {
        public string Name { get; set; } = Name;

        // EF
        public IEnumerable<Product> Products { get; set; } = default!;
    }
}
