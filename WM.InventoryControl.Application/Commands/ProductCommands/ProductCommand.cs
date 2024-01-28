using MediatR;
using System.ComponentModel.DataAnnotations;

namespace WM.InventoryControl.Application.Commands.ProductCommands
{
    public record AddProductCommand(string Name, int Quantity, decimal Price, Guid CategoryId, Guid SupplierId) : IRequest<Guid>
    {
        [Required(ErrorMessage = "O nome e obrigatorio.")]
        public string Name { get; private set; } = Name;

        [Required(ErrorMessage = "A quantidade e obrigatorio.")]
        public int Quantity { get; private set; } = Quantity;

        [Required(ErrorMessage = "O Preço e obrigatorio.")]
        public decimal Price { get; private set; } = Price;

        [Required(ErrorMessage = "O Id da categoria e obrigatorio.")]
        public Guid CategoryId { get; private set; } = CategoryId;

        [Required(ErrorMessage = "O Id do fornecedor e obrigatorio.")]
        public Guid SupplierId { get; set; } = SupplierId;
    }

    public record UpdateProductCommand(Guid Id, string Name, int Quantity, decimal Price, Guid CategoryId) : IRequest
    {
        [Required(ErrorMessage = "O nome e obrigatorio.")]
        public string Name { get; private set; } = Name;

        [Required(ErrorMessage = "A quantidade e obrigatorio.")]
        public int Quantity { get; private set; } = Quantity;

        [Required(ErrorMessage = "O Preço e obrigatorio.")]
        public decimal Price { get; private set; } = Price;

        [Required(ErrorMessage = "O Id da categoria e obrigatorio.")]
        public Guid CategoryId { get; private set; } = CategoryId;

    }

    public record DeleteProductCommand(Guid Id, string Name, int Quantity, decimal Price, Guid CategoryId) : IRequest { }
}
