using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace WM.InventoryControl.Application
{
    public static class ConfigurationServices
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(x =>
            {
                x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Controler de estoque",
                    Description = "Api para controle de estoque"
                });

                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "WM.InventoryControl.Api.xml"));
            });        

            return services;
        }

        public static void AddAppApplication(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger(options =>
                {
                    options.SerializeAsV2 = true;
                });

                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    options.RoutePrefix = string.Empty;                   
                });
            }
        }
    }
}
