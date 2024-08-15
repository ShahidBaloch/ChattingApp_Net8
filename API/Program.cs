using API.Data;
using API.Extensions;
using API.Interfaces;
using API.Services;
using System.Text;

var services = WebApplication.CreateBuilder(args);

// Add services to the container.

services.Services.AddApplicationServics(services.Configuration);
services.Services.AddIdentityServices(services.Configuration);

var app = services.Build();

// Configure the HTTP request pipeline.
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200", "https://localhost:4200"));
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
