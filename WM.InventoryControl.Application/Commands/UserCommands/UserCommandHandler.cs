using MediatR;
using Microsoft.Extensions.Configuration;
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
            var employee = await _employeeService.GetEmployeeByEmailAsync(request.Email) ?? throw new Exception("Email/Senha inválidos.");

            var userId = await _unitOfWork.AddAsync<User>(new User(Guid.NewGuid(), request.Email, request.Password, employee.Id));

            await _unitOfWork.SaveChangesAsync();

            return userId;
        }

        public async Task<string> Handle(AddLoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetUserAsync(request.Email) ?? throw new Exception("Email/Senha inválidos.");

            if (!user.Password.Equals(ComputeSha256Hash(request.Password))) throw new Exception("Email/Senha inválidos.");

            return _configuration.GenerationToken(user);
        }

        private static string ComputeSha256Hash(string password)
        {
            byte[] bytes = System.Security.Cryptography.SHA256.HashData(System.Text.Encoding.UTF8.GetBytes(password));

            var builder = new System.Text.StringBuilder();

            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }

            return builder.ToString();
        }
    }
}
