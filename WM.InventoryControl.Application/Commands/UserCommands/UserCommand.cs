using MediatR;

namespace WM.InventoryControl.Application.Commands.UserCommands
{
    public record AddUserCommand(string Email, string Password) : IRequest<Guid>
    {    }
}
