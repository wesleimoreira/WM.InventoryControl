using MediatR;
using System.ComponentModel.DataAnnotations;
using WM.InventoryControl.Application.Commands.AddressCommands;

namespace WM.InventoryControl.Application.Commands.EmployeeCommands
{
    public record AddEmployeeCommand(string Name, string Email, Guid CompanyId, AddressCommand Address) : IRequest<Guid>
    {
        [Required(ErrorMessage = "O nome e obrigatorio.")]
        public string Name { get; private set; } = Name;

        [Required(ErrorMessage = "O Email e obrigatorio.")]
        [EmailAddress(ErrorMessage = "Email inválido.")]
        public string Email { get; private set; } = Email;

        [Required(ErrorMessage = "O Id da empresa e obrigatorio.")]
        public Guid CompanyId { get; private set; } = CompanyId;

        [Required(ErrorMessage = "E obrigatorio cadastrar o endereço.")]
        public AddressCommand Address { get; private set; } = Address;
    }
}
