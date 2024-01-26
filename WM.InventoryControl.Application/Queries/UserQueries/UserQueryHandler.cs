using MediatR;
using Microsoft.Extensions.Configuration;
using WM.InventoryControl.Domain.Entities;
using WM.InventoryControl.Domain.Interfaces;

namespace WM.InventoryControl.Application.Queries.AuthQueries
{
    public class UserQueryHandler(IUserService userService, IConfiguration configuration) : IRequestHandler<UserQuery, string>
    {
        private readonly IUserService _userService = userService;
        private readonly IConfiguration _configuration = configuration;
        public async Task<string> Handle(UserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetUserAsync(request.Email);

            if (user is null) return default!;

            return user.Email;
        }

        public void TokenGenerator(User user)
        {

        }
    }
}
