namespace BankingSystem.Core.DTOs.Report
{
	public class CalculateDepositInterestResultDto
	{
		public string FirstName { get; set; }

		public string LastName { get; set; }

		public long TotalAmount { get; set; }

		public string DepositName { get; set; }

		public long DepositInterest { get; set; }


	}
}
