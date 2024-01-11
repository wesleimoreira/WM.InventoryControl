namespace WM.InventoryControl.Application.Queries.AddressQueries
{
    public record AddressViewModel(Guid Id, string Country, string State, string City, string District, string Street, string ZipCode) { }
}
