using BankingSystem.Core.DTOs.Transaction;
using BankingSystem.Domain.Entities.Account.Customer;

namespace BankingSystem.Core.Statics
{
	public static class TransactionStatics
	{
		public static TransactionResultDtos Transfer_rq_val(TransactionDtos transactionDtos, OpenAccount openAccount)
		{
			if (transactionDtos.Amount > 1000 && string.IsNullOrEmpty(openAccount.Otp))
			{
				return new TransactionResultDtos() { Message = "لطفا رمز پویا را وارد نمایید", IsSuccess = false };

			}
			if (openAccount.TotaAccountBalance < transactionDtos.Amount)
			{
				return new TransactionResultDtos() { Message = "موجودی حساب کافی نیست", IsSuccess = false };
			}
			if (transactionDtos.Cvv2 != openAccount.Cvv2)
			{
				return new TransactionResultDtos() { Message = "شماره cvv2 اشتباه می باشد.", IsSuccess = false };
			}
			if (transactionDtos.CardPassword != openAccount.CardPassword)
			{
				return new TransactionResultDtos() { Message = "رمز کارت اشتباه است.", IsSuccess = false };

			}
			if (transactionDtos.Expmonth != openAccount.Expmonth || transactionDtos.ExpYear != openAccount.ExpYear)
			{
				return new TransactionResultDtos() { Message = "تاریخ کارت صحیح نمیباشد", IsSuccess = false };
			}
			return new TransactionResultDtos() { Message = "عملیات موفق", IsSuccess = true };
		}
	}
}
