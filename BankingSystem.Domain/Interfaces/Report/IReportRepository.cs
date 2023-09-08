using BankingSystem.Domain.Entities.Account.Customer;

namespace BankingSystem.Domain.Interfaces.Report
{
	public interface IReportRepository
	{
		Task<IQueryable<OpenAccount>> GetAllFilterOpenAccount();
	}
}
