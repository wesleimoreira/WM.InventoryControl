using MediatR;
using WM.InventoryControl.Domain.Entities;
using WM.InventoryControl.Domain.Interfaces;

namespace WM.InventoryControl.Application.Commands.AddressCommands
{
    public class AddressCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddressCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<Guid> Handle(AddressCommand request, CancellationToken cancellationToken)
        {
            var address = new Address(Guid.NewGuid(), request.Country, request.State, request.City, request.District, request.Street, request.ZipCode);

            await _unitOfWork.AddAsync<Address>(address);

            return address.Id;
        }
    }
}
