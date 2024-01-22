using MediatR;
using WM.InventoryControl.Domain.Entities;
using WM.InventoryControl.Domain.Interfaces;

namespace WM.InventoryControl.Application.Commands.CompanyCommands
{
    public class CompanyCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddCompanyCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<Guid> Handle(AddCompanyCommand request, CancellationToken cancellationToken)
        {
            var addressId = await _unitOfWork.AddAsync<Address>(new Address(
                    Guid.NewGuid(),
                    request.Address.Country,
                    request.Address.State,
                    request.Address.City,
                    request.Address.District,
                    request.Address.Street,
                    request.Address.ZipCode));

            var companyId = await _unitOfWork.AddAsync<Company>(new Company(Guid.NewGuid(), request.Name, addressId));

            await _unitOfWork.SaveChangesAsync();

            return companyId;
        }
    }
}
