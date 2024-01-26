namespace WM.InventoryControl.Domain.Entities
{
    public class User(Guid Id, string Email, string Password, Guid EmployeeId) : EntityBase(Id)
    {
        public string Email { get; private set; } = Email;
        public string Password { get; private set; } = Password;


        // EF
        public Guid EmployeeId { get; private set; } = EmployeeId;
        public Employee Employee { get; private set; } = default!;
    }
}
