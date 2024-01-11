using MediatR;
using WM.InventoryControl.Domain.Entities;
using WM.InventoryControl.Domain.Interfaces;

namespace WM.InventoryControl.Application.Commands.SaleCommands
{
    public class SaleCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddSaleCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Guid> Handle(AddSaleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var saleId = await _unitOfWork.AddAsync<Sale>(new Sale(Guid.NewGuid(), request.Quantity, request.Price, DateTime.Now));

                var saleProducts = new List<SaleProduct>();

                foreach (var productId in request.Products)
                    saleProducts.Add(new SaleProduct(Guid.NewGuid(), saleId, productId));

                await _unitOfWork.AddRangeAsync<SaleProduct>(saleProducts);

                await _unitOfWork.SaveChangesAsync();

                return saleId;
            }
            catch
            {

                throw;
            }
        }
    }
}
