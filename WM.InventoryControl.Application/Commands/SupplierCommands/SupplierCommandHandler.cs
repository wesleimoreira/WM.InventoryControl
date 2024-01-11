using MediatR;
using WM.InventoryControl.Domain.Entities;
using WM.InventoryControl.Domain.Interfaces;

namespace WM.InventoryControl.Application.Commands.SupplierCommands
{
    public class SupplierCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddSupplierCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Guid> Handle(AddSupplierCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var addressId = await _unitOfWork.AddAsync<Address>(new Address(
                    Guid.NewGuid(),
                    request.Address.Country,
                    request.Address.State,
                    request.Address.City,
                    request.Address.District,
                    request.Address.Street,
                    request.Address.ZipCode));

                var supplierId = await _unitOfWork.AddAsync<Supplier>(new Supplier(Guid.NewGuid(), request.Name, addressId));

                await _unitOfWork.SaveChangesAsync();

                return supplierId;
            }
            catch
            {
                throw;
            }
        }
    }
}
