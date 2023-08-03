namespace BankingSystem.Core.DTOs.Account.Customer
{
	public class OpenAccountDto
	{
		public int BranchId { get; set; }

		public int DepositId { get; set; }

		public long CustomerId { get; set; }

		public long TotaAccountBalance { get; set; }

		public int ExpDate { get; set; }
    }
}
