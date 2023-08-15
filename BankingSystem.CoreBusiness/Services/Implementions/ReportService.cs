using BankingSystem.Core.DTOs.Report;
using BankingSystem.Core.DTOs.Transaction;
using BankingSystem.Core.Extensions;
using BankingSystem.CoreBusiness.Services.Interfaces;
using BankingSystem.Domain.Entities.Account.Customer;
using BankingSystem.Domain.Entities.Branch;
using BankingSystem.Infra.Data.Context;
using BankingSystem.Infra.Data.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.CoreBusiness.Services.Implementions
{
	public class ReportService : IReportService
	{
		private readonly BankingSystemDbContext _context;
		private readonly Domain.Interfaces.GenericRepository.IGenericRepository<OpenAccount> _genericRepositoryOpenAccount;


		public ReportService(BankingSystemDbContext context)
        {
			_context = context;
			_genericRepositoryOpenAccount = new GenericRepository<OpenAccount>(_context);
		}
		public async Task<CalculateDepositInterestResultDto> GetCalculateDepositInterest(CalculateDepositInterestDto calculateDepositInterestDto)
		{
			var calculateDepositInterestResult = _genericRepositoryOpenAccount.Get(o => o.CustomerId == calculateDepositInterestDto.CustomerId 
			&& o.BranchId == calculateDepositInterestDto.BranchId && o.DepositId == calculateDepositInterestDto.DepositId
			, null, "Deposit,Customer").FirstOrDefault();
			var result = calculateDepositInterestResult.GetCalculateDepositInterestResult(calculateDepositInterestDto.Day);
			return result;
		}
	}
}
