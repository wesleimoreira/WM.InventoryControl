using MediatR;
using WM.InventoryControl.Domain.Entities;
using WM.InventoryControl.Domain.Interfaces;

namespace WM.InventoryControl.Application.Commands.EmployeeCommands
{
    public class EmployeeCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddEmployeeCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Guid> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            var addressId = await _unitOfWork.AddAsync<Address>(new Address(
                   Guid.NewGuid(),
                   request.Address.Country,
                   request.Address.State,
                   request.Address.City,
                   request.Address.District,
                   request.Address.Street,
                   request.Address.ZipCode));

            var employeeId = await _unitOfWork.AddAsync<Employee>(new Employee(Guid.NewGuid(), request.Name, request.Email, request.CompanyId, addressId));

            await _unitOfWork.SaveChangesAsync();

            return employeeId;
        }
    }
}
