using MediatR;
using WM.InventoryControl.Application.Commands.AddressCommands;
using WM.InventoryControl.Domain.Entities;
using WM.InventoryControl.Domain.Interfaces;

namespace WM.InventoryControl.Application.Commands.SupplierCommands
{
    public class SupplierCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddSupplierCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Guid> Handle(AddSupplierCommand request, CancellationToken cancellationToken)
        {
            var addressId = await _unitOfWork.AddAsync<Address>(AddressCommand.AddAddress(request.Address));

            var supplierId = await _unitOfWork.AddAsync<Supplier>(new Supplier(Guid.NewGuid(), request.Name, addressId));

            await _unitOfWork.SaveChangesAsync();

            return supplierId;
        }
    }
}
