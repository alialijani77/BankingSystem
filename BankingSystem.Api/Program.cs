using BankingSystem.Core.DTOs.Account.Customer;
using BankingSystem.Infra.Data.Context;
using BankingSystem.Infra.Ioc;
using Microsoft.EntityFrameworkCore;

#region Services
var builder = WebApplication.CreateBuilder(args);

#region DbContext
builder.Services.AddDbContext<BankingSystemDbContext>(options => options.
UseSqlServer(builder.Configuration.GetConnectionString("BankingSystemDbContext")));
#endregion
#region RegisterDependencies
DependencyContainer.RegisterDependencies(builder.Services);
#endregion
#endregion

#region MiddleWare
// Add services to the container.
builder.Services.Configure<OpenAccountDto>(builder.Configuration.GetSection("OpenAccountManagment"));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
#endregion

