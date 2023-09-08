namespace BankingSystem.Core.DTOs.Report
{
	public class CalculateOpenAccountDepositLotteryDto
	{
		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string AccountNumber { get; set; }

		public string CardNumber { get; set; }

		public string DepositName { get; set; }

		public int DepositLotteryPoints { get; set; }

	}
}
