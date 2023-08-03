namespace BankingSystem.Domain.Entities.Transaction
{
	public class Transaction
	{
		public long Id { get; set; }

		public DateTime Dt { get; set; }

		public string DebugTag { get; set; }

		public string SrcCardNumber { get; set; }

		public string DstCardNumber { get; set; }

		public long Amount { get; set; }

		public int TrnSeq { get; set; }
	}
}
