using BankingSystem.Core.DTOs.Transaction;

namespace BankingSystem.CoreBusiness.Services.Interfaces
{
	public interface ITransactionService
	{
		Task<TransactionResultDtos> Transfer(TransactionDtos transactionDtos);

		Task<string> GetOtp(GetOtpDtos getOtp);

		Task<string> GetShaba(GetShabaDtos getShaba);
	}
}
