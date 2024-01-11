using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace WM.InventoryControl.Application
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(x =>
            {
                x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            return services;
        }
    }
}
