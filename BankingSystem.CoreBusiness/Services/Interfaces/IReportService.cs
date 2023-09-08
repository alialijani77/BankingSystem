using BankingSystem.Core.DTOs.Report;

namespace BankingSystem.CoreBusiness.Services.Interfaces
{
	public interface IReportService
	{
		Task<CalculateDepositInterestResultDto> GetCalculateDepositInterest(CalculateDepositInterestDto calculateDepositInterestDto);

		Task<List<GetOpenAccountForDepositLotteryDto>> GetOpenAccountForDepositLottery(long minMoneyForDepositLottery,long customerId);

		Task<List<CalculateOpenAccountDepositLotteryDto>> CalculateOpenAccountDepositLottery(long customerId);
		
		Task<List<LotteryResultDto>> Lottery(LotteryDto lotteryDto);

		Task<FacilityResultDto> Facility(FacilityResultDto facilityResultDto);

	}
}
