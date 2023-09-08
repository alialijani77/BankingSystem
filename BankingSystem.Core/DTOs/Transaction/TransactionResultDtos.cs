namespace BankingSystem.Core.DTOs.Transaction
{
	[Serializable]
	public class TransactionResultDtos
	{
		public bool IsSuccess { get; set; }

		public string Message { get; set; }
	}
}
