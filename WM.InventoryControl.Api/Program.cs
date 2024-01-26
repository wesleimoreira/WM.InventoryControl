using WM.InventoryControl.Application;
using WM.InventoryControl.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddApplication(builder.Configuration)
    .AddInfrastructure(builder.Configuration.GetConnectionString("InventoryControl") ?? string.Empty);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseStaticFiles();

app.UseHttpsRedirection();

app.AddAppApplication();

app.MapControllers();

app.Run();
