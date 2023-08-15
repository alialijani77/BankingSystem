using BankingSystem.CoreBusiness.Services.Implementions;
using BankingSystem.CoreBusiness.Services.Interfaces;
using BankingSystem.Domain.Interfaces.UnitOfWork;
using BankingSystem.Infra.Data.Repositories.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;


namespace BankingSystem.Infra.Ioc
{
    public static class DependencyContainer
	{
		public static void RegisterDependencies(IServiceCollection services)
		{
			#region Services
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IBranchService, BranchService>();
			services.AddScoped<ICustomerService, CustomerService>();
			services.AddScoped<IDepositService, DepositService>();
			services.AddScoped<ITransactionService, TransactionService>();
			services.AddScoped<IReportService, ReportService>();
			#endregion
			#region Repositories
			//services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
			services.AddScoped<IUnitOfWork, UnitOfWork>();
			#endregion
		}
	}
}
