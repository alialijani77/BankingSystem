using BankingSystem.Core.DTOs.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.CoreBusiness.Services.Interfaces
{
	public interface ITransactionService
	{
		Task<TransactionResultDtos> Transfer(TransactionDtos transactionDtos);
	}
}
