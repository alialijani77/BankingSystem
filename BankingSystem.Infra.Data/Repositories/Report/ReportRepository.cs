using BankingSystem.Domain.Entities.Account.Customer;
using BankingSystem.Domain.Interfaces.Report;
using BankingSystem.Infra.Data.Context;

namespace BankingSystem.Infra.Data.Repositories.Report
{
	public class ReportRepository : IReportRepository
	{
		private readonly BankingSystemDbContext _context;

		public ReportRepository(BankingSystemDbContext context)
        {
            _context = context;
        }
        public async Task<IQueryable<OpenAccount>> GetAllFilterOpenAccount()
		{
			return _context.OpenAccounts.Where(t => !t.IsDelete).AsQueryable();

		}
	}
}
