using MediatR;
using System.ComponentModel.DataAnnotations;
using WM.InventoryControl.Application.Commands.AddressCommands;

namespace WM.InventoryControl.Application.Commands.CompanyCommands
{
    public record AddCompanyCommand(string Name, AddressCommand Address) : IRequest<Guid>
    {
        [Required(ErrorMessage = "O nome e obrigatorio.")]
        public string Name { get; private set; } = Name;

        [Required(ErrorMessage = "E obrigatorio cadastrar o endereço.")]
        public AddressCommand Address { get; private set; } = Address;
    }
}
