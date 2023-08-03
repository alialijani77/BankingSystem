namespace BankingSystem.Core.DTOs.Deposit
{
	public class UpdateDepsoitDto
	{
        public int DepositId { get; set; }

		public string DepositName { get; set; }

		public int DepositInterestRate { get; set; }
	}
}
