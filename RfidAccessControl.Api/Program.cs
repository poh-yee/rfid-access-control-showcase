using Microsoft.EntityFrameworkCore;
using RfidAccessControl.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Configure MySQL database connection via Pomelo EF Core
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

var app = builder.Build();

app.UseAuthorization();
app.MapControllers();

app.Run();