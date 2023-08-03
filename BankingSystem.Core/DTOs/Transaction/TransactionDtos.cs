namespace BankingSystem.Core.DTOs.Transaction
{
	public class TransactionDtos
	{
		public string SrcCardNumber { get; set; }

		public int Cvv2 { get; set; }

		public string Expmonth { get; set; }

		public string ExpYear { get; set; }

		public int CardPassword { get; set; }

		public string Otp { get; set; }

		public string DstCardNumber { get; set; }

		public long Amount { get; set; }


	}
}
