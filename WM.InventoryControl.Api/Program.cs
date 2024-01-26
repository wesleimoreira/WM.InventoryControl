using WM.InventoryControl.Application;
using WM.InventoryControl.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration.GetConnectionString("InventoryControl") ?? string.Empty);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

/// ---------------------------
var app = builder.Build();

app.UseStaticFiles();

app.AddAppApplication();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
