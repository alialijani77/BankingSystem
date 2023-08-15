using BankingSystem.Core.DTOs.Deposit;
using BankingSystem.Core.DTOs.Report;
using BankingSystem.Domain.Entities.Account.Customer;
using BankingSystem.Domain.Entities.Deposit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Core.Extensions
{
	public static class ReportExtensions
	{
		public static CalculateDepositInterestResultDto GetCalculateDepositInterestResult(this OpenAccount openAccount, int day)
		{
			var calculateDepositInterestResultDto = new CalculateDepositInterestResultDto();
			calculateDepositInterestResultDto.FirstName = openAccount.Customer.FirstName;
			calculateDepositInterestResultDto.LastName = openAccount.Customer.LastName;
			calculateDepositInterestResultDto.DepositName = openAccount.Deposit.DepositName;
			calculateDepositInterestResultDto.TotalAmount = openAccount.Customer.TotalAmount;
			calculateDepositInterestResultDto.DepositInterest = (openAccount.Deposit.DepositInterestRate * openAccount.Customer.TotalAmount * day) / 36500;
			return calculateDepositInterestResultDto;
		}
	}
}
