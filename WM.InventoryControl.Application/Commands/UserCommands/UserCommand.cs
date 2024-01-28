using MediatR;
using System.ComponentModel.DataAnnotations;

namespace WM.InventoryControl.Application.Commands.UserCommands
{
    public record AddUserCommand(string Email, string Password) : IRequest<Guid>
    {
        [Required(ErrorMessage = "Email obrigatório.")]
        [EmailAddress(ErrorMessage = "Email inválido.")]
        public string Email { get; private set; } = Email;

        [Required(ErrorMessage = "Senha obrigatório.")]
        public string Password { get; private set; } = Password;
    }

    public record AddLoginCommand(string Email, string Password) : IRequest<string>
    {
        [Required(ErrorMessage = "Email obrigatório.")]
        [EmailAddress(ErrorMessage = "Email inválido.")]
        public string Email { get; private set; } = Email;

        [Required(ErrorMessage = "Senha obrigatório.")]
        public string Password { get; private set; } = Password;
    }
}
