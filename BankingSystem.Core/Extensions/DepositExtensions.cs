using BankingSystem.Core.DTOs.Deposit;
using BankingSystem.Domain.Entities.Deposit;

namespace BankingSystem.Core.Extensions
{
	public static class DepositExtensions
	{
		#region Deposit
		public static Deposit NewDepsoit(this DepsoitDto depsoitDto)
		{
			var deposit = new Deposit();
			deposit.DepositName = depsoitDto.DepositName;
			deposit.DepositInterestRate = depsoitDto.DepositInterestRate;
			return deposit;
		}

		public static Deposit UpdateDepsoit(this UpdateDepsoitDto updateDepsoitDto, Deposit deposit)
		{
			deposit.DepositName = updateDepsoitDto.DepositName;
			deposit.DepositInterestRate = updateDepsoitDto.DepositInterestRate;
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
