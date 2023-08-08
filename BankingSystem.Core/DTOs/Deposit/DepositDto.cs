namespace BankingSystem.Core.DTOs.Deposit
{
	public class DepositDto
	{
		public string DepositName { get; set; }

		public int DepositInterestRate { get; set; }

		public int DepositDailyPointsRate { get; set; }

		public int DepositFacilityPointsRate { get; set; }
	}
}
