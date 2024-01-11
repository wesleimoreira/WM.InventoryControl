namespace WM.InventoryControl.Domain.Entities
{
    public class EntityBase(Guid Id)
    {
        public Guid Id { get; private set; } = Id;
    }
}
