using MediatR;
using WM.InventoryControl.Application.Validators;
using WM.InventoryControl.Domain.Entities;
using WM.InventoryControl.Domain.Interfaces;

namespace WM.InventoryControl.Application.Commands.UserCommands
{
    public class UserCommandHandler(IUnitOfWork unitOfWork, IEmployeeService employeeService) : IRequestHandler<AddUserCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IEmployeeService _employeeService = employeeService;

        public async Task<Guid> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeService.GetEmployeeByEmailAsync(request.Email);

            if (employee is null) return default!;

            var userId = await _unitOfWork.AddAsync<User>(UserValidator.AddUser(request.Email, request.Password, employee.Id));

            await _unitOfWork.SaveChangesAsync();

            return userId;
        }
    }
}
