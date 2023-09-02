using BankingSystem.Core.DTOs.Report;
using BankingSystem.Core.Extensions;
using BankingSystem.CoreBusiness.Services.Interfaces;
using BankingSystem.Domain.Entities.Account.Customer;
using BankingSystem.Infra.Data.Context;
using BankingSystem.Infra.Data.Repositories.GenericRepository;

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
		public async Task<List<GetOpenAccountForDepositLotteryDto>> GetOpenAccountForDepositLottery(long minMoneyForDepositLottery, long customerId)
		{
			var GetOpenAccountForDepositLottery = _genericRepositoryOpenAccount.Get(o => o.TotaAccountBalance >= minMoneyForDepositLottery && o.CustomerId == customerId
			, null, "Deposit,Customer").ToList();

			var result = GetOpenAccountForDepositLottery.GetOpenAccountForDepositLotteryResult();
			return result;
		}

		public async Task<List<CalculateOpenAccountDepositLotteryDto>> CalculateOpenAccountDepositLottery(long customerId)
		{
			var GetOpenAccountForDepositLottery = _genericRepositoryOpenAccount.Get(o => o.CustomerId == customerId
			, null, "Deposit,Customer").ToList();
			//task when all
			var updateDepositLotteryPoints = await GetOpenAccountForDepositLottery.CalculateOpenAccountDepositLottery();
			foreach (var item in updateDepositLotteryPoints)
			{
				await _genericRepositoryOpenAccount.Update(item);
			}
			var result = await updateDepositLotteryPoints.CalculateOpenAccountDepositLotteryResult();
			return result;
		}

		public Task<List<LotteryResultDto>> Lottery(LotteryDto lotteryDto)
		{
			var GetOpenAccountLottey = _genericRepositoryOpenAccount.Get(o => o.DepositLotteryPoints >= lotteryDto.MinDepositLotteryPoints
			, null, "Deposit,Customer").ToList();

			var result = GetOpenAccountLottey.GetLotteryResult(lotteryDto.Count);

			return result;

		}
	}
}
