using BankingSystem.Core.DTOs.Branch;
using BankingSystem.Core.DTOs.Deposit;
using BankingSystem.Domain.Entities.Branch;
using BankingSystem.Domain.Entities.Deposit;

namespace BankingSystem.Core.Extensions
{
	public static class DepositExtensions
	{
		#region Deposit
		public static IEnumerable<DepositDto> GetDeposit(this IEnumerable<Deposit> deposits)
		{

			var depositDtos = new List<DepositDto>();
			foreach (var item in deposits)
			{
				var depositDto = new DepositDto();
				depositDto.DepositName = item.DepositName;
				depositDto.DepositInterestRate = item.DepositInterestRate;
				depositDto.DepositDailyPointsRate = item.DepositDailyPointsRate;
				depositDto.DepositFacilityPointsRate = item.DepositFacilityPointsRate;
				depositDtos.Add(depositDto);
			}
			return depositDtos;
		}
		public static DepositDto GetDepositById(this Deposit deposit)
		{
			var depositDto = new DepositDto();
			depositDto.DepositName = deposit.DepositName;
			depositDto.DepositInterestRate = deposit.DepositInterestRate;
			depositDto.DepositDailyPointsRate = deposit.DepositDailyPointsRate;
			depositDto.DepositFacilityPointsRate = deposit.DepositFacilityPointsRate;
			return depositDto;
		}

		public static Deposit NewDepsoit(this AddDepsoitDto depsoitDto)
		{
			var deposit = new Deposit();
			deposit.DepositName = depsoitDto.DepositName;
			deposit.DepositInterestRate = depsoitDto.DepositInterestRate;
			deposit.DepositDailyPointsRate = depsoitDto.DepositDailyPointsRate;
			deposit.DepositFacilityPointsRate = depsoitDto.DepositFacilityPointsRate;
			return deposit;
		}

		public static Deposit UpdateDepsoit(this UpdateDepsoitDto updateDepsoitDto, Deposit deposit)
		{
			deposit.DepositName = updateDepsoitDto.DepositName;
			deposit.DepositInterestRate = updateDepsoitDto.DepositInterestRate;
			deposit.DepositDailyPointsRate = updateDepsoitDto.DepositDailyPointsRate;
			deposit.DepositFacilityPointsRate = updateDepsoitDto.DepositFacilityPointsRate;
			deposit.CreateDate = DateTime.Now;
			return deposit;
		}

		public static Deposit DeleteDeposit(this Deposit deposit)
		{
			deposit.IsDelete = true;
			deposit.CreateDate = DateTime.Now;
			return deposit;
		}


		#endregion
	}
}
