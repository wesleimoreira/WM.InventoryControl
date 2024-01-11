using MediatR;
using WM.InventoryControl.Domain.Entities;
using WM.InventoryControl.Domain.Interfaces;

namespace WM.InventoryControl.Application.Commands.ProductCommands
{
    public class ProductCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddProductCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Guid> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product = ProductValidator.IsProductValid(new Product(Guid.NewGuid(), request.Name, request.Quantity, request.Price, request.CategoryId));

                var productId = await _unitOfWork.AddAsync<Product>(product);

                await _unitOfWork.SaveChangesAsync();

                return productId;
            }
            catch
            {
                throw;
            }
        }
    }
}
