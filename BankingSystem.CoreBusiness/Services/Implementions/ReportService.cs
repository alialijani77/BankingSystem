using BankingSystem.Core.DTOs.Report;
using BankingSystem.Core.Extensions;
using BankingSystem.CoreBusiness.Services.Interfaces;
using BankingSystem.Domain.Entities.Account.Customer;
using BankingSystem.Domain.Interfaces.Report;
using BankingSystem.Infra.Data.Context;
using BankingSystem.Infra.Data.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.CoreBusiness.Services.Implementions
{
	public class ReportService : IReportService
	{
		private readonly BankingSystemDbContext _context;
		private readonly Domain.Interfaces.GenericRepository.IGenericRepository<OpenAccount> _genericRepositoryOpenAccount;
		private readonly IReportRepository _reportRepository;


		public ReportService(BankingSystemDbContext context, IReportRepository reportRepository)
		{
			_context = context;
			_genericRepositoryOpenAccount = new GenericRepository<OpenAccount>(_context);
			_reportRepository = reportRepository;
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

		public async Task<List<LotteryResultDto>> Lottery(LotteryDto lotteryDto)
		{
			var GetOpenAccountLottey = _genericRepositoryOpenAccount.Get(o => o.DepositLotteryPoints >= lotteryDto.MinDepositLotteryPoints
			, null, "Deposit,Customer").ToList();

			var result = await GetOpenAccountLottey.GetLotteryResult(lotteryDto.Count);

			return result;

		}

		public async Task<FacilityResultDto> Facility(FacilityResultDto facilityResultDto)
		{
			var query = await _reportRepository.GetAllFilterOpenAccount();
			if (facilityResultDto.DepositFacilityPoints != null && facilityResultDto.DepositFacilityPoints != 0) 
			{
				query = query.Include(o => o.Deposit).Include(t => t.Customer)
					.Where(o => o.DepositFacilityPoints >= facilityResultDto.DepositFacilityPoints);
			}

			if (facilityResultDto.BranchId != null && facilityResultDto.BranchId != 0)
			{
				query = query.Include(o => o.Deposit).Include(t => t.Customer)
					.Where(o => o.Branch.BranchId == facilityResultDto.BranchId);
			}
			if (facilityResultDto.DepositId != null && facilityResultDto.DepositId != 0)
			{
				query = query.Include(o => o.Deposit).Include(t => t.Customer)
					.Where(o => o.Deposit.DepositId == facilityResultDto.BranchId);
			}
			switch (facilityResultDto.Sort)
			{
				case 1:
					query = query.OrderByDescending(q => q.CreateDate);
					break;
				case 2:
					query = query.OrderBy(q => q.CreateDate);
					break;
			}
			var result = query.Select(q => new FacilityDto()
			{
			FirstName = q.Customer.FirstName,
			LastName = q.Customer.LastName,
			DepositFacilityPoints = q.DepositFacilityPoints,
			CardNumber = q.CardNumber,
			Shaba = q.Shaba
			}).AsQueryable();

			await facilityResultDto.SetPaging(result);

			return facilityResultDto;
		}
	}
}
