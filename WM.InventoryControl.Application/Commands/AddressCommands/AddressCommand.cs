using MediatR;
using System.ComponentModel.DataAnnotations;
using WM.InventoryControl.Domain.Entities;

namespace WM.InventoryControl.Application.Commands.AddressCommands
{
    public record AddressCommand(string Country, string State, string City, string District, string Street, string ZipCode) : IRequest<Guid>
    {
        [Required(ErrorMessage = "O pais e obrigatorio.")]
        public string Country { get; private set; } = Country;

        [Required(ErrorMessage = "O Estado e obrigatorio.")]
        [Length(2, 2, ErrorMessage = "O Estado deve ter 2 digitos.")]
        public string State { get; private set; } = State;

        [Required(ErrorMessage = "A Cidade e obrigatoria.")]
        public string City { get; private set; } = City;

        [Required(ErrorMessage = "O bairro e obrigatório.")]
        public string District { get; private set; } = District;

        [Required(ErrorMessage = "A rua e obrigatoria.")]
        public string Street { get; private set; } = Street;

        [Required(ErrorMessage = "O cep e obrigatório.")]
        [Length(8, 8, ErrorMessage = "O CEP deve ter 8 digitos.")]
        public string ZipCode { get; private set; } = ZipCode;


        public static Address AddAddress(AddressCommand address)
        {
            return new Address(Guid.NewGuid(), address.Country, address.State, address.City, address.District, address.Street, address.ZipCode);
        }
    }
}
