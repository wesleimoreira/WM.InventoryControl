using MediatR;
using WM.InventoryControl.Domain.Entities;
using WM.InventoryControl.Domain.Interfaces;

namespace WM.InventoryControl.Application.Commands.PurchaseCommands
{
    public class PurchaseCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<ADDPurchaseCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Guid> Handle(ADDPurchaseCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var purchaseId = await _unitOfWork.AddAsync<Purchase>(new Purchase(Guid.NewGuid(), request.Quantity, request.Price, DateTime.Now));

                var purchaseProducts = new List<PurchaseProduct>();

                foreach (var productId in request.Products)
                    purchaseProducts.Add(new PurchaseProduct(Guid.NewGuid(), productId, purchaseId));

                await _unitOfWork.AddRangeAsync<PurchaseProduct>(purchaseProducts);

                await _unitOfWork.SaveChangesAsync();

                return purchaseId;
            }
            catch
            {

                throw;
            }
        }
    }
}
