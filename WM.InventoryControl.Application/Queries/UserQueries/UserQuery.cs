using MediatR;

namespace WM.InventoryControl.Application.Queries.AuthQueries
{
    public record UserQuery(string Email, string Password) : IRequest<string> { }
}
