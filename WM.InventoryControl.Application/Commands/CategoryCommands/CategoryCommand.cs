using MediatR;
using System.ComponentModel.DataAnnotations;

namespace WM.InventoryControl.Application.Commands.CategoryCommands
{
    public record AddCategoryCommand(string Name) : IRequest<Guid>
    {
        [Required(ErrorMessage = "O nome e obrigatorio.")]
        public string Name { get; private set; } = Name;
    }

    public record DeleteCategoryCommand(Guid Id, string Name) : IRequest { }
}
