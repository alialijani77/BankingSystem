
using BankingSystem.Api.Middleware;
using BankingSystem.Core.DTOs.Account.Customer;
using BankingSystem.Core.DTOs.ApiResult;
using BankingSystem.Infra.Data.Context;
using BankingSystem.Infra.Ioc;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

#region Services
var builder = WebApplication.CreateBuilder(args);

#region DbContext
builder.Services.AddDbContext<BankingSystemDbContext>(options => options.
UseSqlServer(builder.Configuration.GetConnectionString("BankingSystemDbContext")));
#endregion

#region Authentication
builder.Services.AddAuthentication(options =>
{
	options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
	options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
	options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options =>
{
	options.LoginPath = "/Login";
	options.LogoutPath = "/Logout";
	options.ExpireTimeSpan = TimeSpan.FromDays(30);
});

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



//builder.Services.Configure<ApiBehaviorOptions>(
//			  options => options.InvalidModelStateResponseFactory = actionContext =>
//			  {
//				  actionContext.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
//				  return new JsonResult(ApiResultDto<string>.BadRequest(actionContext.ModelState));
//			  }
//			  );
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionMiddleware>();
app.UseExceptionHandler("/error");
//app.UseHsts();
//app.UseStatusCodePages();
//app.UseExceptionHandler(c => c.Run(async context =>
//{
//	var exception = context.Features
//		.Get<IExceptionHandlerPathFeature>()
//		.Error;
//	var response = new { error = exception.Message };
//	await context.Response.WriteAsJsonAsync(response);
//}));
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
#endregion

