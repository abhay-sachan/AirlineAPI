using AirlineProjectAPI.Controllers;
using Microsoft.EntityFrameworkCore;
using AirlineProjectAPI.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<AirlineProjectAPIDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("AirlineConn")));

builder.Services.AddCors(c => c.AddPolicy("AirlineProject", c => c.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader()));
builder.Services.AddEndpointsApiExplorer();
// Configure the HTTP request pipeline.
builder.Services.AddScoped<IAuthenticate, AuthenticateImpl>();
builder.Services.AddScoped<IAdmin, AdminImpl>();
builder.Services.AddScoped<IApplicationOwner, ApplicationOwnerImpl>();
builder.Services.AddScoped<ICustomer, CustomerImpl>();


var app = builder.Build();
app.MapControllers();
app.UseRouting();
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();

app.Run();


