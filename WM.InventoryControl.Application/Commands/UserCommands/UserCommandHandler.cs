using MediatR;
using Microsoft.Extensions.Configuration;
using WM.InventoryControl.Application.Validators;
using WM.InventoryControl.Domain.Entities;
using WM.InventoryControl.Domain.Interfaces;

namespace WM.InventoryControl.Application.Commands.UserCommands
{
    public class UserCommandHandler(IUnitOfWork unitOfWork, IEmployeeService employeeService, IUserService userService, IConfiguration configuration) : IRequestHandler<AddUserCommand, Guid>, IRequestHandler<AddLoginCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IUserService _userService = userService;
        private readonly IConfiguration _configuration = configuration;
        private readonly IEmployeeService _employeeService = employeeService;

        public async Task<Guid> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeService.GetEmployeeByEmailAsync(request.Email);

            if (employee is null) return Guid.Empty;

            var userId = await _unitOfWork.AddAsync<User>(UserValidator.AddUser(request.Email, request.Password, employee.Id));

            await _unitOfWork.SaveChangesAsync();

            return userId;
        }

        public async Task<string> Handle(AddLoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetUserAsync(request.Email);

            if (user is null) return default!;

            if (!user.Password.Equals(UserValidator.ComputeSha256Hash(request.Password))) return default!;

            return _configuration.GenerationToken(user);
        }
    }
}
