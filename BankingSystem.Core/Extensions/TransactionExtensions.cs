using BankingSystem.Core.DTOs.Transaction;
using BankingSystem.Core.Generator;
using BankingSystem.Domain.Entities.Account.Customer;
using BankingSystem.Domain.Entities.Branch;
using BankingSystem.Domain.Entities.Transaction;

namespace BankingSystem.Core.Extensions
{
	public static class TransactionExtensions
	{
		public static Transaction NewTransaction(this TransactionDtos transactionDtos)
		{
			var transaction = new Transaction();
			transaction.Dt = DateTime.Now;
			transaction.SrcCardNumber = transactionDtos.SrcCardNumber;
			transaction.DstCardNumber = transactionDtos.DstCardNumber;
			transaction.Amount = transactionDtos.Amount;
			transaction.TrnSeq = RandomGenerator.TrnSeq();
			transaction.DebugTag = "Transfer";
			return transaction;
		}
		public static Branch UpdateBranchAfterSrcTransaction(this Branch branch, long Amount)
		{
			branch.TotalAmount -= Amount;
			branch.CreateDate = DateTime.Now;
			return branch;
		}

		public static Branch UpdateBranchAfterDstTransaction(this Branch branch, long Amount)
		{
			branch.TotalAmount += Amount;
			branch.CreateDate = DateTime.Now;
			return branch;
		}

		public static Customer UpdateCustomerAfterSrcTransaction(this Customer customer, long Amount)
		{
			customer.TotalAmount -= Amount;
			customer.CreateDate = DateTime.Now;
			return customer;
		}

		public static Customer UpdateCustomerAfterDstTransaction(this Customer customer, long Amount)
		{
			customer.TotalAmount += Amount;
			customer.CreateDate = DateTime.Now;
			return customer;
		}

		public static OpenAccount UpdateOtp(this OpenAccount openAccount, GetOtpDtos getOtp)
		{
			openAccount.Otp = RandomGenerator.GetOtp();
			openAccount.CreateDate = DateTime.Now;
			return openAccount;
		}
	}
}
